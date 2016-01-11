using UnityEngine;
using System.Collections;

public class Bullet_Destroy : MonoBehaviour {

    public float limitRange = 100;  //後々ステータスにまとめます。
    Vector3 StartPos;

    //public ParticleSystem particle;

	// Use this for initialization
	void Start () {
        StartPos = transform.position;
//        particle = GetComponent<ParticleSystem>();
        //particle.simulationSpace = ParticleSystemSimulationSpace.World;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, StartPos) >= limitRange)
        {
            Destroy(gameObject);
        }
	
	}
}
