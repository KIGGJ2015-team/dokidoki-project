// ----- ----- ----- ----- -----
//
// PlayerImporter
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/PlayerImporter")]
public class PlayerImporter : MonoBehaviour
{
	#region 変数
    [SerializeField, Tooltip("モデルデータ")]
    private List<GameObject> modelData;

    [SerializeField, Tooltip("プレイヤーのバレット")]
    private GameObject bullet;

    [SerializeField, Tooltip("プレイヤーカメラ")]
    private GameObject coreCamera;

    [SerializeField, Tooltip("レーダーカメラ")]
    private GameObject radarCamera;

    [SerializeField, Tooltip("標準オブジェクト")]
    private GameObject reticle;

    [SerializeField, Tooltip("チェックポイントの数")]
    private int checkPointNumber;

    [SerializeField, Tooltip("開始位置")]
    private Vector3 startingPosition;

    #endregion


    #region プロパティ
    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        GameObject   selectManager = GameObject.Find("SelectManager");
        
        PlayerSelect manager       = selectManager.GetComponent<PlayerSelect>();
        
        GameObject   player        = Instantiate(modelData[manager.State], startingPosition, Quaternion.identity) as GameObject;
        GameObject   spawn         = new GameObject("Spawn");

        modelData.RemoveAt(manager.State);

        //子に設定
        spawn.transform.parent = player.transform;

        //プレイヤースクリプトの設定
        player.AddComponent<Player_Move>();
        Player_Shot shot = player.AddComponent<Player_Shot>();
        shot.bullet      = bullet;
        shot.spawn       = spawn.transform;

        player.AddComponent<CheckPointManager>().checkPointNumber = checkPointNumber;

        //当たり判定の設定
        Rigidbody rigidbody   = player.AddComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity  = false;

        spawn.AddComponent<Player_Reticle>().reticule = reticle;

        spawn.transform.position = new Vector3(0, 0, 8.0f);

        coreCamera .GetComponent<Camera_Control>().fighter     = player;
        radarCamera.GetComponent<ObjectChaser  >().chaseObject = player;

        int i = 1;
        foreach(GameObject model in modelData)
        {
            GameObject rival      = Instantiate(model, startingPosition + new Vector3(20, 0, 0) * i, Quaternion.identity) as GameObject;
            GameObject rivalspawn = new GameObject("spawn");
            RivalRacerAI ai = rival.AddComponent<RivalRacerAI>();
            ai.spawn  = rivalspawn;
            ai.bullet = bullet;

            rival.AddComponent<CheckPointManager>().checkPointNumber = checkPointNumber;

            Rigidbody rivalRigidbody = rival.AddComponent<Rigidbody>();
            rivalRigidbody.isKinematic = false;
            rivalRigidbody.useGravity  = false;

            i++;
        }

        Destroy(selectManager);
    }

    // 更新前処理
    void Start() { }

    // 更新処理
    void Update() { }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(startingPosition, 1.0f);
    }
	#endregion
}