using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    float time = 3;
    [SerializeField]
    bool isStart = false;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ((int)time).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            isStart = true;
        }
	}
    public bool GetisStart()
    {
        return isStart;
    }
}
