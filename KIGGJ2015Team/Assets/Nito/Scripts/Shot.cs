using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawn;
    public float speed = 1000;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject obj = GameObject.Instantiate(bullet) as GameObject;
        obj.transform.position = spawn.position;
        Vector3 force;
        force = this.gameObject.transform.forward * speed;
        obj.GetComponent<Rigidbody>().AddForce(force);
    }
}
