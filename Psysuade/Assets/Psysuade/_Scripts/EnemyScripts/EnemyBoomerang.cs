using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoomerang : MonoBehaviour
{
    [Header("Set in Inspector: EnemyBoomerang")]
    public float frequency = 20.0f;
    public float magnitude = 0.5f;
    private Vector3 axis;
    private Vector3 pos;
    public float lifeTime = 2;
    public float projectileSpeed = 5;
    public Transform prefabHero;
    private Vector3 target;
    // Start is called before the first frame update
    void Awake()
    {
        pos = transform.position;
        axis = transform.right;

        prefabHero = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(prefabHero.position.x, prefabHero.position.y);
        //pos += Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        //transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        //pos += (transform.position * projectileSpeed * Time.deltaTime).normalized;
        transform.position = pos * Mathf.Sin(Time.time * frequency) * magnitude;
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
