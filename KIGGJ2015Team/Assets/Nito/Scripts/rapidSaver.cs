using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class rapidSaver : MonoBehaviour
{


    public Image gage;
    public float loadedBullets;
    public float speed = 0.01f;

    // Use this for initialization
    void Start()
    {
        loadedBullets = gage.fillAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        loadedBullets = loadedBullets + speed;
        if (loadedBullets >= 1)
        {
            loadedBullets = 0.01f;
        }

        gage.fillAmount = loadedBullets;
    }

    public void AddScore(float Addhp)
    {
        loadedBullets = loadedBullets + Addhp;
    }
}
