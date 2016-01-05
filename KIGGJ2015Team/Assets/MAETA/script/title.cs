using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

    [SerializeField, Tooltip("シーンを管理するオブジェクト")]
    GameObject sceneManager;

    SceneManager manager;

	// Use this for initialization
	void Start () {
	    manager = sceneManager.GetComponent<SceneManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stage_select()
    {
        //機体選択へ
        manager.SceneChange(SceneName.SelectScene);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
