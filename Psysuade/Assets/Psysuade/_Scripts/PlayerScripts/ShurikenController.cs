using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public float speed;
    public float timeToLive;

    Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = Vector3.up * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector);
    }
}
