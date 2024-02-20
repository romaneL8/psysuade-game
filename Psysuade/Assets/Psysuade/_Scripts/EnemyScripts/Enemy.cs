using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxEnemyHealth = 5;
    public Transform target;
    public float speed = 10;
    public float minDist = 2;
    SpriteRenderer sRend;

    [SerializeField]
    private int _enemyHealth;

    public int enemyHealth
    {
        get { return _enemyHealth; }
        set { _enemyHealth = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        enemyHealth = maxEnemyHealth;
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //sRend.
        Track();
        //if (target.transform.position.x > transform.position.x)
        //{

        //}
        //else if (target.transform.position.x < transform.position.x)
        //{

        //}
        this.sRend.flipX = target.transform.position.x < this.transform.position.x;
    }

    public virtual void Track()
    {
        if (target == null)
        {
            return;
        }

        //transform.LookAt(target);

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > minDist)
        {
            //transform.position += transform.forward * speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PlayerShuriken")
        {
            Destroy(collidedWith);
            enemyHealth -= 1;
        }

        //PlayerSword

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
