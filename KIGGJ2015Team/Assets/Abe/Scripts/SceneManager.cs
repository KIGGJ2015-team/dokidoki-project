// ----- ----- ----- ----- -----
//
// SceneManager
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/SceneManager")]
public class SceneManager : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("フェードのスピード"), Range(0, 1)]
    float fadeSpeed;

    GameObject frame;
    Image      fadePanel;

    #endregion


    #region プロパティ

    private bool FadeActive
    {
        set
        {
            frame.SetActive(value);
        }
    }

    private float FadeAlpha
    {
        set
        {
            Color color = fadePanel.color;
            color.a = value;
            fadePanel.color = color;
        }
    }

    private Color FadeColor
    {
        set
        {
            fadePanel.color = value;
        }
    }

    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        if(GameObject.Find("SceneManager1"))
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        gameObject.name = "SceneManager1";

        frame     = transform.GetChild(0).gameObject;
        fadePanel = frame.transform.GetChild(0).GetComponent<Image>();
        fadePanel.color = new Color(0, 0, 0, 0);
        FadeActive = false;
    }

    // 更新前処理
    void Start()
    {
        
    }

    // 更新処理
    void Update()
    {
        
    }

    public void SceneChange(SceneName sceneName)
    {
        FadeActive = true;
        StartCoroutine(FadeIn(sceneName));
    }

    public void SceneChange(SceneName sceneName, Color color)
    {
        FadeColor = color;
        SceneChange(sceneName);
    }
    
    IEnumerator FadeIn(SceneName sceneName)
    {
        for(float i = 0; i <= 1; i += fadeSpeed)
        {
            FadeAlpha = i;
            yield return null;
        }
        Application.LoadLevel(sceneName.ToString());
    }

    void OnLevelWasLoaded(int level)
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        //フェードアウト
        for(float i = 1; i >= 0; i -= fadeSpeed)
        {
            FadeAlpha = i;
            yield return null;
        }
        FadeActive = false;
    }

	#endregion
}