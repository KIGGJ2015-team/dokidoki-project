using UnityEngine;
using System.Collections;

public class Bullet_Destroy : MonoBehaviour {

    GameObject player;
    public float limitRange = 100;  //後々ステータスにまとめます。


	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) >= limitRange)
        {
            Destroy(gameObject);
        }
	
	}
}
