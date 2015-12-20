using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

    [SerializeField,Tooltip("カメラの回転速度"),Range(0,1)]
    public float rotateSpeed;       //カメラの回転速度
    public GameObject fighter;
    Vector3 fighterPos;
	// Use this for initialization
	void Start () {
        
        
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Lerp(transform.rotation, fighter.transform.rotation, rotateSpeed);
        transform.position = fighter.transform.position;


//        if (transform.localRotation.x <= -30 || transform.localRotation.x >= 80) transform.Rotate();

    }
}
