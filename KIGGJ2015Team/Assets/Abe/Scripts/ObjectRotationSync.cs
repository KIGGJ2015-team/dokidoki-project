// ----- ----- ----- ----- -----
//
// ObjectRotationSync
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

[AddComponentMenu("MyScript/ObjectRotationSync")]
public class ObjectRotationSync : MonoBehaviour
{
	#region 変数

	//[Header("タイトル")]
    
	//[SerializeField, Tooltip("説明文")]

    public enum SyncType
    {
        None  = 0,
        X     = 1,
        Y     = 2,
        XandY = 3,
        Z     = 4,
        ZandX = 5,
        ZandY = 6,
        ALL   = 7,
    }
	
    public GameObject chaseObject;
    public SyncType   syncType;

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
        Vector3 rotate = transform.rotation.eulerAngles;

        //ChaseType
        if (((int)syncType & 1) > 0)
        {
            rotate.x = chaseObject.transform.rotation.eulerAngles.x;
        }

        if (((int)syncType & 2) > 0)
        {
            rotate.y = chaseObject.transform.rotation.eulerAngles.y;
        }

        if (((int)syncType & 4) > 0)
        {
            rotate.z = chaseObject.transform.rotation.eulerAngles.z;
        }
        
        transform.rotation = Quaternion.Euler(rotate);
    }
	#endregion
}