using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrower : Enemy {
    [Header("Set in Inspector: EnemyThrower")]
    //public float rotSpeed = 10;
    //public float rotation = 60f;
    public float minAttackDist = 6;
    public GameObject projectilePrefab;
    public GameObject mouthPrefab;
    public bool moving;
    public bool attacking;
    public int ammo = 1;

    void Start()
    {
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        InvokeRepeating("AddAmmo", 10f, 3f);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > minAttackDist)
        {
            moving = true;
        } else
        {
            moving = false;
            if (ammo < 1)
            {
                return;
            } else
            {
                Attack();
            }
        }
        if (moving == true)
        {
            Track();
        }
        //else
        //{
        //    Attack();
        //}
        if (ammo < 1)
        {
            attacking = true;
        } else
        {
            attacking = false;
        }
        if (ammo > 1)
        {
            ammo = 1;
        }
    }

    public override void Track()
    {
        base.Track();
    }

    void Attack()
    {
        GameObject go = Instantiate(projectilePrefab);
        //go.transform.position = mouthPrefab.transform.position;
        go.transform.position = this.transform.position;
        ammo--;
    }

    void AddAmmo()
    {
        if (ammo <= 0)
        {
            ammo++;
        } else
        {
            return;
        }
    }
}
