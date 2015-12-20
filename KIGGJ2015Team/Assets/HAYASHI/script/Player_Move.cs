using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    public enum Yaxis
    {
        normal,
        reverse
    };

    [SerializeField, TooltipAttribute("前進スピード")]
    public float speed;
    [SerializeField, TooltipAttribute("旋回スピード")]
    public float RotateSpeed;
    [SerializeField, TooltipAttribute("上下反転の有無")]
    public Yaxis yaxis;
    [SerializeField, Tooltip("ブースト速度")]
    public float boostSpeed;
    [SerializeField, Tooltip("ロール速度")]
    public float rollSpeed;

    float VRotateSpeed;     //Ｙ軸のスピード
    float time = 0;         //時間計測
    Quaternion vec;
    GameObject fighter;

    Player_Status playerstatus;

    // Use this for initialization
    void Start () {
        fighter = GameObject.Find("fighter");
	
	}
	
	// Update is called once per frame
	void Update () {
        vec = transform.rotation;
        Yreverse();
        transform.Rotate(transform.up, RotateSpeed * Input.GetAxisRaw("Horizontal"),Space.World);
        transform.Rotate(Vector3.right, VRotateSpeed * Input.GetAxisRaw("Vertical"),Space.Self);
        if (Input.GetAxisRaw("Boost") < 1)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
        else transform.Translate(Vector3.forward * boostSpeed * Time.deltaTime, Space.Self);
        rolling();
        keepStability();
	}

    void rolling()
    {
        if (Input.GetAxisRaw("Horizontal")>0)
        {
            if (Input.GetButton("Boost"))
            {
                transform.Translate(Vector3.right * rollSpeed * Time.deltaTime, Space.Self);
            }
        }
        else if (Input.GetAxisRaw("Horizontal")<0)
        {
            if (Input.GetButton("Boost")) transform.Translate(-Vector3.right * rollSpeed * Time.deltaTime, Space.Self);
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
                VRotateSpeed = -RotateSpeed;
                break;
            case Yaxis.reverse:
                VRotateSpeed = RotateSpeed;
                break;
        }

    }
}
