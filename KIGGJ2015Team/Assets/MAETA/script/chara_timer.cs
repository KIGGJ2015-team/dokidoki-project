using UnityEngine;
using System.Collections;

public class chara_timer : MonoBehaviour {
    [SerializeField]
    float time_chara ;
    [SerializeField]
    bool isMove = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time_chara -= Time.deltaTime;

        if (time_chara < 0) time_chara = 0;
        {
            isMove = true;
        }
    }
    public bool GetisStart()
    {
        return isMove;
    }
}
