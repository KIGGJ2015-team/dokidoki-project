using UnityEngine;
using System.Collections;

public class Player_Status : MonoBehaviour {

    public enum PlayerType{
        zero,
        human,
        dragon,
        SF,
        DEBUG

    };
    public PlayerType playertype;



    [SerializeField, TooltipAttribute("前進スピード")]
    private float speed;
    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }
    [SerializeField, TooltipAttribute("旋回スピード")]
    private float rotatespeed;
    public float RotateSpeed
    {
        set { rotatespeed = value; }
        get { return rotatespeed; }
    }
    [SerializeField, Tooltip("ブースト速度")]
    private float boostspeed;
    public float BoostSpeed
    {
        set { boostspeed = value; }
        get { return boostspeed; }
    }
    [SerializeField, Tooltip("ブースト時間")]
    private float boostlimit;
    public float Boostlimit
    {
        set { boostlimit = value; }
        get { return boostlimit; }
    }
    [SerializeField, Tooltip("ブーストクールタイム")]
    private float boostcooling;
    public float BoostCooling
    {
        set { boostcooling = value; }
        get { return boostcooling; }
    }
    [SerializeField, Tooltip("ローリング速度")]
    private float rollingspeed;
    public float RollingSpeed
    {
        set { rollingspeed = value; }
        get { return rollingspeed; }
    }
    [SerializeField, Tooltip("ローリング判定時間")]
    private float rollinglimittime;
    public float RollingLimitTime
    {
        set { rollinglimittime = value; }
        get { return rollinglimittime; }
    }

    [SerializeField, Tooltip("弾の速さ")]
    private float bulletspeed;
    public float BulletSpeed
    {
        set { bulletspeed = value; }
        get { return bulletspeed; }
    }

    [SerializeField, Tooltip("弾の発射間隔")]
    private float bulletinterbal;
    public float BulletInterbal
    {
        set { bulletinterbal = value; }
        get { return bulletinterbal; }
    }

    [SerializeField, Tooltip("攻撃力")]
    private float damage;
    public float Damage
    {
        set { damage = value; }
        get { return damage; }
    }

    [SerializeField, Tooltip("HP")]
    private float hp;
    public float HP
    {
        set { hp = value; }
        get { return hp; }
    }

    public bool isControl = false;
    

    // Use this for initialization
    void Start () {
        switch (playertype)
        {
            case PlayerType.zero:
                speed = 40;
                rotatespeed = 1.2f;
                boostspeed = 100;
                boostlimit = 4;
                boostcooling = 0.1f;
                RollingSpeed = 15;
                RollingLimitTime = 0.5f;
                bulletspeed = 1000;
                bulletinterbal = 0.5f;
                damage = 30;     //未定
                hp = 300;         //未定
                break;
            case PlayerType.dragon:
                speed = 40;
                rotatespeed = 1.2f;
                boostspeed = 90;
                boostlimit = 3;
                boostcooling = 0.1f;
                RollingSpeed = 15;
                RollingLimitTime = 0.5f;
                bulletspeed = 1000;
                bulletinterbal = 0.5f;
                damage = 100;     //未定
                hp = 300;         //未定

                break;
            case PlayerType.human:
                speed = 50;
                rotatespeed = 1.5f;
                boostspeed = 110;
                boostlimit = 6;
                boostcooling = 0.1f;
                RollingSpeed = 15;
                RollingLimitTime = 0.5f;
                bulletspeed = 1000;
                bulletinterbal = 0.5f;
                damage = 10;     //未定
                hp = 90;         //未定

                break;
            case PlayerType.SF:
                speed = 40;
                rotatespeed = 1;
                boostspeed = 120;
                boostlimit = 3;
                boostcooling = 0.1f;
                RollingSpeed = 15;
                RollingLimitTime = 0.5f;
                bulletspeed = 1000;
                bulletinterbal = 0.5f;
                damage = 50;     //未定
                hp = 300;         //未定

                break;
            case PlayerType.DEBUG:
                speed = 0;
                rotatespeed = 0;
                boostspeed = 0;
                boostlimit = 0;
                boostcooling = 0;
                RollingSpeed = 0;
                RollingLimitTime = 0;
                bulletspeed = 0;
                damage = 0;
                break;
        }
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
