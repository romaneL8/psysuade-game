using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour
{
    private float nextDash;

    public float dashCoolDownTime = 5f;

    public float dashSpeed = 1f;

    private Vector2 dashVect;

    MovementController movementCtrl;

    //float aX = Input.GetAxis("Horizontal");
    //float aY = Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Awake()
    {
        movementCtrl = GameObject.Find("Player").GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement = new Vector2(aX, aY);

        //Vector3 moveDir = (new Vector3(aX, aY)).normalized * movementCtrl.speed;

        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDash && movement != Vector2.zero)
        //{
        //    dashVect = movement.normalized;
        //    nextDash = Time.time + dashCoolDownTime;
        //    transform.position += moveDir * dashSpeed * Time.deltaTime;
        //}

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDash && movementCtrl.moving == true)
        {
            //dashVect = movementCtrl.speed * spee
            nextDash = Time.time + dashCoolDownTime;
//transform.position += moveDir * dashSpeed * Time.deltaTime;
        }
    }
}
