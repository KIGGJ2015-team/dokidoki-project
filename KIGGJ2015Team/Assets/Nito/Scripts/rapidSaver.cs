using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class rapidSaver : MonoBehaviour
{


    public Image gage;
    private float loadedBullets;
    public float speed = 0.01f;

    public int msBulletCounter;


    // Use this for initialization
    void Start()
    {
        loadedBullets = 0.0f;
        gage.fillAmount = loadedBullets;
    }

    // Update is called once per frame
    void Update()
    {

        loadedBullets = loadedBullets + 0.01f;
        if (loadedBullets <= 0)
        {
            loadedBullets = 0;
        }
        if (loadedBullets >= 1)
        {
            loadedBullets = 1;
        }
        gage.fillAmount = loadedBullets;
    }

    public void AddBullet(float Add)
    {
        loadedBullets = loadedBullets + Add;
    }

    public float GetScore()
    {
        return loadedBullets;
    }
    
}
