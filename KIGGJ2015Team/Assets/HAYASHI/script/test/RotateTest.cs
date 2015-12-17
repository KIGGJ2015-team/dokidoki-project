using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up, Mathf.Clamp(Time.deltaTime, 10, 90));

    }
}
