// ----- ----- ----- ----- -----
//
// GameInfomation
//
// 作成日：
// 作成者：
//
// <概要>
// 進行の状況を出力します
//
// ----- ----- ----- ----- -----

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/GameInformation")]
public class GameInformation : MonoBehaviour
{
	#region 変数

	//[Header("タイトル")]
    
	[SerializeField, Tooltip("フェードのスピード"), Range(0, 1)]
    float fadeSpeed;

    [SerializeField, Tooltip("表示する時間")]
    float showTime;

    private Text InformationText;
	
    #endregion


    #region プロパティ

    public float InformationTextAlpha
    {
        get { return InformationText.color.a; }

        set
        {
            Color color = InformationText.color;
            color.a = value;
            InformationText.color = color;
        }
    }

    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        InformationText = GetComponent<Text>();
    }

    // 更新前処理
    void Start()
    {
        InformationTextAlpha = 0;
        InformationText.text = "";
    }

    // 更新処理
    void Update()
    {
        
    }

    public void ShowInformation(string message)
    {
        InformationText.text  = message;
        StartCoroutine(Show());
        //Show -> Wait -> Hideの順に処理が変わっていく
    }

    IEnumerator Show()
    {
        //フェードイン
        for(float i = 0; i <= 1; i += fadeSpeed)
        {
            InformationTextAlpha = i;
            yield return null;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        //この間表示
        yield return new WaitForSeconds(showTime);
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        //フェードアウト
        for(float i = 1; i >= 0; i -= fadeSpeed)
        {
            InformationTextAlpha = i;
            yield return null;
        }
        InformationTextAlpha = 0;
        InformationText.text = "";
    }
	#endregion
}