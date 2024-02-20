using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttackController : MonoBehaviour
{
    private Rigidbody2D rigid;

    private bool isSlashAttackButtonDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSlashAttackButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (isSlashAttackButtonDown)
        {
            SlashAttack();
        }
    }

    void SlashAttack()
    {

    }
}
