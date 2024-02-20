using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatProjectile : MonoBehaviour
{
    public float lifeTime = 5;
    public float projectileSpeed = 5;
    public Transform prefabHero;
    private Vector3 target;

    // Use this for initialization
    void Awake()
    {
        prefabHero = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(prefabHero.position.x, prefabHero.position.y);
        Die();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
    }

    void Die()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
