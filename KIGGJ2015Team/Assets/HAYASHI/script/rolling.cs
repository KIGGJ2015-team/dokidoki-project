using UnityEngine;
using System.Collections;

public class rolling : MonoBehaviour {

    Vector3 currentVec;
    Vector3 targetVec;
    float count = 0;

	// Use this for initialization
	void Start () {
        currentVec = new Vector3(0, 0, 0);
        targetVec = new Vector3(0, 0, 45);
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.Slerp(currentVec, targetVec, count));
            if (count >= 0) count += Time.deltaTime;

            if (count >= 1) count = -5;

        }
	
	}
}
