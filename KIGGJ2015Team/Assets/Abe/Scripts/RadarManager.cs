// ----- ----- ----- ----- -----
//
// RadarManager
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

[AddComponentMenu("MyScript/RadarManager")]
public class RadarManager : MonoBehaviour
{
    #region 変数

    //[Header("タイトル")]

    //[SerializeField, Tooltip("説明文")]

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
        ObjectDeactive();
    }

    // 更新処理
    void Update()
    {
        
    }

    public void ObjectDeactive()
    {
        var objs = GameObject.FindGameObjectsWithTag("Radar");

        foreach(var obj in objs)
        {
            obj.GetComponent<Renderer>().enabled = false;
        }
    }
	#endregion
}