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

    Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        fighter = GameObject.Find("fighter");
        system = GameObject.Find("System");
        playerstatus = system.GetComponent<Player_Status>();

        rigidbody = GetComponent<Rigidbody>();

	
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

    void SpeedChange()
    {
        if (Input.GetButton("Boost"))
        {
            boosttime += Time.deltaTime;
            if (boosttime <= playerstatus.Boostlimit)
            {
                speed = playerstatus.BoostSpeed;
//                Debug.Log("boostON");
            }else
            {
                speed = playerstatus.Speed;
//                Debug.Log("boostLIMIT");
            }
            
        }else
        {
            boosttime = 0;
            speed = playerstatus.Speed;
//            Debug.Log("boostOFF");
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
                transform.Translate(Vector3.right * playerstatus.RollingSpeed * Time.deltaTime, Space.Self);
                rollingflg = false;
                rollingTime = 0;
            }else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("doubleTap:L");
                transform.Translate(-Vector3.right * playerstatus.RollingSpeed * Time.deltaTime, Space.Self);
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
