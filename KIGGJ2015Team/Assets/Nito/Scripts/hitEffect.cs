using UnityEngine;
using System.Collections;
using System;

public class hitEffect : MonoBehaviour {

	public void OnCollisionEnter(Collision Bullet)
    {
        GetComponent <ParticleSystem>().Play();
        
    }
}
