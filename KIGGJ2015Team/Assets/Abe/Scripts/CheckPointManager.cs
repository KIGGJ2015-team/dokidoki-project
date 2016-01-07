// ----- ----- ----- ----- -----
//
// CheckPoint
//
// 作成日：
// 作成者：
//
// <概要>
// どこのチェックポイントを
// 通ってきたのかを管理します
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

    [SerializeField, Tooltip("情報を表示するテキスト")]
    private GameObject informationText;

    #endregion


    #region プロパティ

    public List<GameObject> KeyItemsData
    {
        get { return keyItemsData; }
    }

    public int CheckPointNumber
    {
        get { return checkPointNumber; }
    }

    public bool IsGetAllKey
    {
        get
        {
            return keyItemsData.Count >= checkPointNumber;
        }
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

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
        if(IsGetAllKey)
        {
            //ゴールの処理
            Debug.Log("Goal Open");
            //informationText.GetComponent<GameInformation>().ShowInformation("ゴールオープン！");
        }
    }

    //ランダムでキーを落とす
    void LostKey()
    {
        int count = keyItemsData.Count;

        int lostNumber = Random.Range(0, count-1);

        keyItemsData.RemoveAt(lostNumber);

        //表示関係にどのキーが落ちたかを通知する
#warning 後で実装
    }
	#endregion
}