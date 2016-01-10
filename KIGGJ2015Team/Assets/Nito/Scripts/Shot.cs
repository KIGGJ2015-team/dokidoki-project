using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawn;
    public float speed = 1000;

    public rapidSaver shooter;
   
    void start()
    {
        shooter.GetComponent<rapidSaver>();

    }
   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) &&
            shooter.GetScore()>0.25f)
        {
            shooter.AddBullet(-0.25f);
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
