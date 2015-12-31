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
        pHp = gage.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        pHp = pHp + speed;
        if (pHp >= 1)
        {
           pHp = 0.01f;
        }

        gage.fillAmount = pHp;
    }

    public void AddScore(float Addhp)
    {
        pHp = pHp + Addhp;
    }
}
