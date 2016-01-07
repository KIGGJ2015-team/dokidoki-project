// ----- ----- ----- ----- -----
//
// Radar
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

[AddComponentMenu("MyScript/Radar")]
public class Radar : MonoBehaviour
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
        
    }

    // 更新処理
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().enabled = false;
    }
	#endregion
}