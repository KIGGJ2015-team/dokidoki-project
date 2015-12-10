using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    public float Speed ;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f) * Time.deltaTime * Speed;
    }
    void Reflect()
    {
       //  GetComponent<Rigidbody>().AddForce(Vector3.up * 15.0f, ForceMode.Impulse);
    }
}
