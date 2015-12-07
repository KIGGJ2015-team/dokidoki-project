// ----- ----- ----- ----- -----
//
// PlayerTestMove
//
// 作成日：
// 作成者：
//
// <概要>
// 仮に作ったPlayerの移動です
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/PlayerTestMove")]
public class PlayerTestMove : MonoBehaviour
{
	#region 変数

	//[Header("タイトル")]
    
	[SerializeField, Tooltip("移動のスピード")]
	float speed;

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
        Vector3 position = transform.position;
        position.x += Input.GetAxisRaw("Horizontal") * speed;
        transform.position = position;
    }
	#endregion
}