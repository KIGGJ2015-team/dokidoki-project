// ----- ----- ----- ----- -----
//
// PlayerInfomation
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

[AddComponentMenu("MyScript/PlayerInfomation")]
public class PlayerInfomation : MonoBehaviour
{
	#region 変数

    //[SerializeField, Tooltip("説明文")]
    public List<GameObject> rival = new List<GameObject>();
    public GameObject player;

    #endregion


    #region プロパティ

    public GameObject Player
    {
        get { return player; }

        set { player = value;}
    }

    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        
    }

    // 更新前処理
    void Start()
    {
        
    }

    // 更新処理
    void Update()
    {
        
    }

    public void RivalAdd(GameObject rivalObject)
    {
        rival.Add(rivalObject);
    }

    public List<GameObject> GetRival()
    {
        return rival;
    }

	#endregion
}