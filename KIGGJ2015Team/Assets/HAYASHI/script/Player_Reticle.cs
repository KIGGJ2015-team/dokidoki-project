using UnityEngine;
using System.Collections;

public class Player_Reticle : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public float limitrange;
    GameObject reticule;

	// Use this for initialization
	void Start () {
        reticule = GameObject.Find("reticle");
	
	}
	
	// Update is called once per frame
	void Update () {
        ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray,out hit, limitrange))
        {
            reticule.transform.position = hit.transform.position;
        }else
        {
            reticule.transform.position = ray.GetPoint(limitrange);
        }
	
	}
}
