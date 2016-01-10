using UnityEngine;
using System.Collections;

public class title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	     
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stage_select()
    {
        //機体選択へ
        GameObject.Find("SceneManager1").GetComponent<SceneManager>().SceneChange(SceneName.SelectScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
