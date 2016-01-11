using UnityEngine;
using System.Collections;

public class result : MonoBehaviour {


    int score; // 今回のプレイスコアがはいっているものとして
    int hiscore = PlayerPrefs.GetInt("HISCORE");
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (score > hiscore)
        {
            //scoreをハイスコアとして表示
            /// 今回のスコアがハイスコアより大きいので保存
            PlayerPrefs.SetInt("HISCORE", score);
        }
        else
        {
            // hiscoreをハイスコアとして表示
        }
    }
}
