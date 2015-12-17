using UnityEngine;
using System.Collections;

public class Player_Status : MonoBehaviour {
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
    [SerializeField, Tooltip("ローリング速度")]
    private float rollingspeed;
    public float RollingSpeed
    {
        set { rollingspeed = value; }
        get { return rollingspeed; }
    }
    [SerializeField, Tooltip("弾の速さ")]
    private float bulletspeed;
    public float BulletSpeed
    {
        set { bulletspeed = value; }
        get { return bulletspeed; }
    }

    // Use this for initialization
    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
