using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class playerHp : MonoBehaviour
{


    public Image gage;
    public float pHp;
    public float speed = 0.01f;

    // Use this for initialization
    void Start()
    {
        pHp = gage.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        pHp = pHp - speed;
        if (pHp <= 0)
        {
           pHp = 1.0f;
        }

        gage.fillAmount = pHp;
    }

    public void AddScore(float Addhp)
    {
        pHp = pHp + Addhp;
    }
}
