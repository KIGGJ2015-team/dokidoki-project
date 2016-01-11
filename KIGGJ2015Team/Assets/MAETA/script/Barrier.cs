using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
    [SerializeField]
    private int life = 2;
    [SerializeField]
    private AudioSource SE;

    public GameObject explosionPrefab;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider coll)
    {
      //coll.gameObject.SendMessage("Reflect");
        if (coll.gameObject.tag == "Barrier"){
            Debug.Log("ataru");
            life--;

            if (life == 0)
            {
               Instantiate (explosionPrefab, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
