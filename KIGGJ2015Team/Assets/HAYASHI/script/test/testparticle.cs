using UnityEngine;
using System.Collections;

public class testparticle : MonoBehaviour {

    float time = 0;
    float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
	
	}
}
