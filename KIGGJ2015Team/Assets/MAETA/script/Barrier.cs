using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {
    
    private int life = 2;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnCollisionEnter(Collision collision)
    {
        // coll.gameObject.SendMessage("Reflect");
        if (collision.gameObject.tag == "Barrier"){
            Debug.Log("ataru");
            life--;

            if (life == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
