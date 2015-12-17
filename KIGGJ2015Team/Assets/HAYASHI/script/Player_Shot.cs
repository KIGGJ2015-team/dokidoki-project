using UnityEngine;
using System.Collections;

public class Player_Shot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawn;
    public float speed = 1000;  //後々ステータスにまとめます


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
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
