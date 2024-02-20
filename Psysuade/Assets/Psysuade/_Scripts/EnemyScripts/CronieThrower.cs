using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronieThrower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int ammo = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddAmmo", 10f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo < 1)
        {
            return;
        } else
        {
            Attack();
        }
        if (ammo > 1)
        {
            ammo = 1;
        }
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
        }
        else
        {
            return;
        }
    }
}
