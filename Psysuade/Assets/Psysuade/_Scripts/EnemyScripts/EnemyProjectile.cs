using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IDeflectable {
    public float lifeTime = 2;
    public float projectileSpeed = 5;
    public Transform prefabHero;
    private Vector3 target;

    private Rigidbody2D rb;

    public float ReturnSpeed { get; set; }

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
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

    public void Deflect(Vector2 direction)
    {
        rb.velocity = direction * ReturnSpeed;
    }
}
