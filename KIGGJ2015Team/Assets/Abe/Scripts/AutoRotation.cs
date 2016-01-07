// ----- ----- ----- ----- -----
//
// AutoRotation
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

[AddComponentMenu("MyScript/AutoRotation")]
public class AutoRotation : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("回る速さ")]
    float rotateSpeed = 0;

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
        Vector3 angle = transform.localRotation.eulerAngles;
        angle.y += rotateSpeed;
        transform.localRotation = Quaternion.Euler(angle);
    }
	#endregion
}