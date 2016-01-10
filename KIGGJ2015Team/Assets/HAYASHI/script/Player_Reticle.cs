using UnityEngine;
using System.Collections;

public class Player_Reticle : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public float limitrange;
    public GameObject reticule;

    // Use this for initialization
    void Start()
    {
        Instantiate(reticule);


    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, limitrange, LayerMask.GetMask("Bullet")))
        {
            reticule.transform.position = hit.transform.position;
        }
        else
        {
            reticule.transform.position = ray.GetPoint(limitrange);
        }

    }
}
