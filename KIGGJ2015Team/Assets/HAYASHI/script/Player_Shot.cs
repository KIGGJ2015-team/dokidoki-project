using UnityEngine;
using System.Collections;

public class Player_Shot : MonoBehaviour {

    public GameObject bullet;
    public Transform spawn;
    Player_Status playerstatus;
    GameObject system;
    public Animator animator;
    float shotTime = 0;
    void Start()
    {
        system = GameObject.Find("System");
        playerstatus = system.GetComponent<Player_Status>();
    }



    void Update()
    {
        if (playerstatus.isControl)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                animator.Play("Shot");
            }
        }
    }

    void Shoot()
    {
        if (shotTime <= playerstatus.BulletInterbal)
        {
            shotTime += Time.deltaTime;
        }
        else if (shotTime > playerstatus.BulletInterbal)
        {
            Debug.Log("shot!");
            GameObject obj = GameObject.Instantiate(bullet) as GameObject;
            obj.transform.position = spawn.position;
            obj.transform.rotation = spawn.rotation;
            Vector3 force;
            force = this.gameObject.transform.forward * playerstatus.BulletSpeed;
            obj.GetComponent<Rigidbody>().AddForce(force);
            shotTime = 0;
        }
    }
}
