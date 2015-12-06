// ----- ----- ----- ----- -----
//
// CheckPoint
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

[AddComponentMenu("MyScript/CheckPoint")]
public class CheckPointManager : MonoBehaviour
{
	#region 変数

	//[Header("タイトル")]
    
	[SerializeField, Tooltip("チェックポイントのデータ")]
    private List<GameObject> keyItemsData;

    [SerializeField, Tooltip("チェックポイントの個数"), Range(1, 100)]
    private int checkPointNumber = 1;


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
        if(other.gameObject.tag != "CheckPoint")
        {
            return;
        }

        //リストと照合同じものを入れないように
        foreach(var obj in keyItemsData)
        {
            if(other.gameObject == obj)
            {
                //無駄な処理をしないように
                return;
            }
        }

        keyItemsData.Add(other.gameObject);
        GoalOpenCheck();
    }

    void GoalOpenCheck()
    {
        if(keyItemsData.Count >= checkPointNumber)
        {
            //ゴールの処理
            Debug.Log("Goal Open");
#warning 後で実装
        }
    }

    void LostKey()
    {
        int count = keyItemsData.Count;

        int lostNumber = Random.Range(0, count-1);

        keyItemsData.RemoveAt(lostNumber);
    }
	#endregion
}