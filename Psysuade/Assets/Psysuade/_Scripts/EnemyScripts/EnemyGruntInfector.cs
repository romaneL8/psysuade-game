using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntInfector : Enemy
{
    [Header("Set in Inspector: EnemyGruntInfector")]
    public float minAttackDist = 2;
    public bool moving;

    void Start()
    {
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance > minAttackDist)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving == true)
        {
            Track();
        }
    }

    public override void Track()
    {
        base.Track();
    }
}
