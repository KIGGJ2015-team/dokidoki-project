using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

    [SerializeField,Tooltip("カメラの回転速度"),Range(0,45)]
    public float rotateSpeed;       //カメラの回転速度
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Camera_Horizontal"),Space.World);
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Camera_Vertical"), Space.Self);
        if (transform.localRotation.x <= -30 || transform.localRotation.x >= 80) Debug.Log("rotatelimit");
	
	}
}
