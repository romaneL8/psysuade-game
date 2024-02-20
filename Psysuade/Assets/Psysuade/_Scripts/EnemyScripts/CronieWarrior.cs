using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronieWarrior : MonoBehaviour
{
    [Header("Set in Inspector: CronieWarrior")]
    public float speed = 9;
    public float minAttackDist = 6;
    public float minDist = 2;
    public GameObject projectilePrefab;
    public Transform target;
    public bool moving;
    public bool attacking;
    public int ammo = 3;
    public float fireRate = 0;
    private float lastShot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        InvokeRepeating("AddAmmo", 5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > minAttackDist)
        {
            moving = true;
        }
        else
        {
            moving = false;
            if (ammo < 1)
            {
                return;
            }
            else
            {
                Attack();
            }
        }
        if (moving == true)
        {
            Track();
        }
        if (ammo < 1)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
        if (ammo > 1)
        {
            ammo = 1;
        }
    }

    void Attack()
    {
        fireRate = 0.1f;
        if (Time.time > fireRate + lastShot && ammo > 0)
        {
            float bulletAngle = Mathf.FloorToInt((10) / 2) * 30;
            Vector3 bulletDist = this.transform.position - target.transform.position;
            for (float i = 0; i < 3; i++, bulletAngle += 30)
            {
                Instantiate(projectilePrefab, this.transform.position, Quaternion.AngleAxis(bulletAngle, bulletDist) * this.transform.rotation);
                projectilePrefab.transform.position += projectilePrefab.transform.forward * speed * Time.deltaTime;
            }
            //GameObject go = Instantiate(projectilePrefab);
            // Arc the bullets

            //go.transform.position = this.transform.position;
            ammo--;
        }

    }

    void Track()
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

    void AddAmmo()
    {
        if (ammo <= 0)
        {
            ammo++;
        }
        else
        {
            return;
        }
    }
}
