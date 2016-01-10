using UnityEngine;
using System.Collections;

public class Player_Shot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawn;
    Player_Status playerstatus;
    GameObject system;
    public Animator animator;

    void Start()
    {
        system = GameObject.Find("System");
        playerstatus = system.GetComponent<Player_Status>();
    }



    void Update()
    {
        if (Input.GetButton("Fire1")) 
        {
            Shoot();
            animator.Play("Shot");
        }
    }

    void Shoot()
    {
        float shotTime = 0;
        if (shotTime <= playerstatus.BulletInterbal)
        {
            shotTime += Time.deltaTime;
        }
        else if (shotTime > playerstatus.BulletInterbal)
        {
            GameObject obj = GameObject.Instantiate(bullet) as GameObject;
            obj.transform.position = spawn.position;
            Vector3 force;
            force = this.gameObject.transform.forward * playerstatus.BulletSpeed;
            obj.GetComponent<Rigidbody>().AddForce(force);
            shotTime = 0;
        }
    }
}
