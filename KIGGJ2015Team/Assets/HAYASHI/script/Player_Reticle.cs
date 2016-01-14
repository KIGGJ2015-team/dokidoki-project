using UnityEngine;
using System.Collections;

public class Player_Reticle : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public float limitrange = 50;
    public GameObject reticule;
    GameObject obj;
    // Use this for initialization
    void Start()
    {
        obj = Instantiate(reticule) as GameObject;


    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, limitrange))
        {
            obj.transform.position = hit.transform.position;
        }
        else
        {
            obj.transform.position = ray.GetPoint(limitrange);
        }
        obj.transform.rotation = transform.rotation;

    }
}
