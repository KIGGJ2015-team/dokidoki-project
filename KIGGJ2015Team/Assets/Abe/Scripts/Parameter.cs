// ----- ----- ----- ----- -----
//
// Parameter
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
using UnityEngine.UI;

[AddComponentMenu("MyScript/Parameter")]
public class Parameter : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("表示するスプライト")]
    private List<Sprite> sprites;

    [SerializeField, Tooltip("セレクト管理オブジェト")]
    private GameObject selectManager;

    private PlayerSelect select;
    private Image image;

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        select = selectManager.GetComponent<PlayerSelect>();
        image  = GetComponent<Image>();
    }

    // 更新前処理
    void Start()
    {
        
    }

    // 更新処理
    void Update()
    {
        image.sprite = sprites[select.State];
    }

	#endregion
}