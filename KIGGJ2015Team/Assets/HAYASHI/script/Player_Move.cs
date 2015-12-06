using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    [SerializeField, TooltipAttribute("前進スピード")]
    public float speed;
    [SerializeField, TooltipAttribute("旋回スピード")]
    public float RotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up, RotateSpeed * Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(transform.forward, Vector3.Slerp(Vector3.zero, new Vector3(0, 0, 60), Input.GetAxisRaw("Horizontal")).z);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
	}
}
