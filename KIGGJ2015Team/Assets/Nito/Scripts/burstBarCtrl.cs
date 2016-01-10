using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class burstBarCtrl : MonoBehaviour
{

    public Image boostGage;
    public float boostlimit;
    public float boostTimeCount;

    void Start()
    {
        //boostlimit = 30.0f;
        boostGage.fillAmount = boostlimit;
        boostTimeCount = 0.0f;
   
    }

    void Update()
    {
        boostTimeCount = 1.0f * Time.deltaTime;

        if (boostlimit < 1)
        {
            boostlimit += 0.5f * Time.deltaTime;
        }

            if (boostlimit > 0 && Input.GetKey(KeyCode.Z))//Zが押されている間ブーストリミットを減少
            {
                boostlimit -= boostTimeCount;
            }
            boostGage.fillAmount = boostlimit;
        
    }

}
