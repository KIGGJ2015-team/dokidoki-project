using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    public enum Yaxis
    {
        normal,
        reverse
    };

    [SerializeField, Tooltip("Y軸の反転")]
    public Yaxis yaxis;

    GameObject system;
    Player_Status playerstatus;

    float speed;

    float VRotateSpeed;     //Ｙ軸のスピード
    float boosttime = 0;

    Quaternion vec;
    GameObject fighter;


    float Rotate;

    bool rollingflg = false;
    float rollingTime = 0;
    float keeprolingtime = 0;

    int keeprolling;    //norolling=0,right=1,left=2


    // Use this for initialization
    void Start () {
        fighter = GameObject.Find("fighter");
        system = GameObject.Find("System");
        playerstatus = system.GetComponent<Player_Status>();

        boosttime = playerstatus.Boostlimit;
	
	}
	
	// Update is called once per frame
	void Update () {
        //プレイヤーの姿勢を保持
        vec = transform.rotation;
        //旋回の判断
        Rotate = Input.GetAxisRaw("Horizontal");



        //Y軸反転
        Yreverse();
        //旋回
        turn(Rotate);
        //ローリング
        if (rollingflg)
        {
            rolling();
         }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rollingflg = true;
            }
        }

        //ブーストの有無
        SpeedChange();
        //常に前進
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        //ボタンを離したら水平に戻る
        keepStability();
    }

    void FixedUpdate()
    {
        if (keeprolling==1)
        {
            keeprolingtime += Time.deltaTime;
            transform.Translate(Vector3.right * playerstatus.RollingSpeed * Time.deltaTime, Space.Self);
            if (keeprolingtime >= 0.5)
            {
                keeprolling = 0;
                keeprolingtime = 0;
            }
        }else if(keeprolling == 2)
        {
            keeprolingtime += Time.deltaTime;
            transform.Translate(-Vector3.right * playerstatus.RollingSpeed * Time.deltaTime, Space.Self);
            if (keeprolingtime >= 0.5)
            {
                keeprolling = 0;
                keeprolingtime = 0;
            }
        }
    }

    void SpeedChange()
    {
        Debug.Log(boosttime);

        if (Input.GetButton("Boost"))
        {
            boosttime -= Time.deltaTime;
            if (boosttime >= 0)
            {
                speed = playerstatus.BoostSpeed;
                Debug.Log("boostON");
            }else
            {
                speed = playerstatus.Speed;
                Debug.Log("boostLIMIT");
            }
            
        }else
        {
            boosttime += Time.deltaTime;
            boosttime = Mathf.Clamp(boosttime, 0, playerstatus.Boostlimit);
            speed = playerstatus.Speed;
            Debug.Log("boostOFF");
        }
    }

    void turn(float rotate)
    {
        Vector3 topos = transform.eulerAngles;
        topos.x = 0;

        if (rotate < 0)
        {
            topos.z = 45;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(topos), 0.1f);
        }
        else if (rotate > 0)
        {
            topos.z = -45;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(topos), 0.1f);
        }
//        Debug.Log(topos);
        transform.Rotate(transform.up, playerstatus.RotateSpeed * rotate, Space.World);
        transform.Rotate(Vector3.right, VRotateSpeed * Input.GetAxisRaw("Vertical"), Space.Self);
    }

    void rolling()
    {
        rollingTime += Time.deltaTime;

        if (rollingTime < 0.5)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("doubleTap:R");
                keeprolling = 1;
                rollingflg = false;
                rollingTime = 0;
            }else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("doubleTap:L");
                keeprolling = 2;
                rollingflg = false;
                rollingTime = 0;
            }
        }
        else
        {
            Debug.Log("reset");
            // reset
            rollingflg = false;
            rollingTime = 0.0f;

        }


    }
    void keepStability()
    {
        if (!Input.anyKey)
        {
            vec.z = 0;
            vec.x = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, vec, 0.05f);
            Debug.Log("keep");
        }

        
    }

    void Yreverse()
    {
        switch (yaxis)
        {
            case Yaxis.normal:
                VRotateSpeed = -playerstatus.RotateSpeed;
                break;
            case Yaxis.reverse:
                VRotateSpeed = playerstatus.RotateSpeed;
                break;
        }

    }
}
