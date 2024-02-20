using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy
{
    [Header("Set in Inspector: EnemyMage")]
    public float minAttackDist = 6;
    public GameObject projectilePrefab;
    public GameObject mouthPrefab;
    public bool moving;
    public bool teleporting;
    public bool attacking;
    public int ammo = 10;
    public int mana = 1;
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

        InvokeRepeating("AddMana", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance > minAttackDist)
        {
            moving = true;
            //teleporting = true;
        }
        else
        {
            moving = false;
            //teleporting = false;
            if (mana < 1)
            {
                return;
            } else
            {
                teleporting = true;
                Teleport();
            }
        }
        if (moving == true)
        {
            teleporting = false;
            Track();
        }
        if (teleporting == true)
        {
            Invoke("Attack", 0.5f);
        }
        //else
        //{
        //    Attack();
        //}
        if (mana < 1)
        {
            teleporting = false;
        }
        else
        {
            return;
        }
        if (mana > 1)
        {
            mana = 1;
        }
    }

    public override void Track()
    {
        base.Track();
    }

    void Teleport()
    {
        Vector2 neartargetPos = target.transform.position;
        //neartargetPos.x = neartargetPos.x + Random.Range(-10.0f, 10.0f);
        //neartargetPos.y = neartargetPos.y + Random.Range(-10.0f, 10.0f);
        transform.position = neartargetPos + Random.insideUnitCircle * 30;
        mana--;
    }

    void Attack()
    {
        fireRate = 0.1f;
        if (Time.time > fireRate + lastShot && ammo > 0)
        {
            float bulletAngle = Mathf.FloorToInt((10) / 2) * 30;
            Vector3 bulletDist = this.transform.position - target.transform.position;
            for (float i = 0; i < 10; i++, bulletAngle += 30)
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

    void AddMana()
    {
        if (mana <= 0)
        {
            mana++;
        }
        else
        {
            return;
        }
    }
}
