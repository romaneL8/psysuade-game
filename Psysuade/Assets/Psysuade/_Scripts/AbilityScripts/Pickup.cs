using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    float lifeTime = 10;

	// Use this for initialization
	void Start () {
        Die();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die()
    {
        Destroy(gameObject, lifeTime);
    }
}
