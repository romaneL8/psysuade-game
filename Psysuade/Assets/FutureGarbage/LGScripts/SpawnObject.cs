using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject[] objects;

	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, objects.Length);
        GameObject Instance = Instantiate(objects[rand], transform.position, Quaternion.identity);
        Instance.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
