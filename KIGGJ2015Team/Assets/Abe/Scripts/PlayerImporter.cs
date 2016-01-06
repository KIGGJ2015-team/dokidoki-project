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

    [SerializeField, Tooltip("プレイヤーとライバルのレーサー")]
    private List<GameObject> importObjects;

    [SerializeField, Tooltip("モデルデータ")]
    private List<GameObject> modelData;


    #endregion


    #region プロパティ
    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        GameObject selectManager = GameObject.Find("SelectManager");
        
        
        
        Destroy(selectManager);
    }

    // 更新前処理
    void Start() { }

    // 更新処理
    void Update() { }
	#endregion
}