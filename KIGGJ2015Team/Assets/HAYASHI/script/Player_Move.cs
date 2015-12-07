﻿using UnityEngine;
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


    float VRotateSpeed;
	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up, RotateSpeed * Input.GetAxisRaw("Horizontal"),Space.World);
        transform.Rotate(Vector3.right, VRotateSpeed * Input.GetAxisRaw("Vertical"),Space.Self);



        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        
	}
}