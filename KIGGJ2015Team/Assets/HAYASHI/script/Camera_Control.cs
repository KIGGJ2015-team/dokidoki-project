using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

    [SerializeField,Tooltip("カメラの回転速度"),Range(0,45)]
    public float rotateSpeed;       //カメラの回転速度
    [SerializeField, Tooltip("カメラ上下の回転制限")]
    public float YrotateMin, YrotateMax;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Camera_Horizontal"),Space.World);
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Camera_Vertical"), Space.Self);
        if (transform.localEulerAngles.x <= -30 || transform.localEulerAngles.x >= 80) Debug.Log("rotatelimit");
	
	}
}
