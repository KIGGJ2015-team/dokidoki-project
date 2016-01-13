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

    #endregion


    #region プロパティ
    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        GameObject   selectManager = GameObject.Find("SelectManager");
        
        PlayerSelect manager       = selectManager.GetComponent<PlayerSelect>();
        
        GameObject   player        = Instantiate(modelData[manager.State]);
        GameObject   spawn         = new GameObject("Spawn");

        modelData.RemoveAt(manager.State);

        //子に設定
        spawn.transform.parent = player.transform;

        //プレイヤースクリプトの設定
        player.AddComponent<Player_Move>();
        Player_Shot shot = player.AddComponent<Player_Shot>();
        shot.bullet      = bullet;
        shot.spawn       = spawn.transform;

        //当たり判定の設定
        Rigidbody rigidbody   = player.AddComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity  = false;

        spawn.AddComponent<Player_Reticle>().reticule = reticle;

        spawn.transform.position = new Vector3(0, 0, 8.0f);

        coreCamera.GetComponent<Camera_Control>().fighter = player;
        radarCamera.GetComponent<ObjectChaser>().chaseObject = player;

        foreach(GameObject model in modelData)
        {

        }

        Destroy(selectManager);
    }

    // 更新前処理
    void Start() { }

    // 更新処理
    void Update() { }
	#endregion
}