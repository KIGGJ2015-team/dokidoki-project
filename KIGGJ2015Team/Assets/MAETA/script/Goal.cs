// ----- ----- ----- ----- -----
//
// Goal
//
// 作成日：
// 作成者：
//
// <概要>
// ゴールの処理です
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/Goal")]
public class Goal : MonoBehaviour
{
	#region 変数

	//[Header("タイトル")]
    
	[SerializeField, Tooltip("プレイヤーのタグ")]
	private string playerTag = "Player";

    [SerializeField, Tooltip("情報を表示するテキスト")]
    private GameObject informationText;

    result result;
    #endregion


    #region プロパティ



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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag)
        {
            if(other.gameObject.GetComponent<CheckPointManager>().IsGetAllKey)
            {
                //ゴール
                PlayerGoal();
            }
        }
    }

    void PlayerGoal()
    {
        //ゴールの処理
        Debug.Log("Goal!!!");
        result.goal = true;
        //informationText.GetComponent<GameInformation>().ShowInformation("ゴール！");
    }
	#endregion
}