using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed = 10f;
    public bool moving;

    public float dashSpeed = 1f;
    public float dashCoolDownTime = 5f;
    private float nextDash;
    private DashCoolDown dashCoolDown;
    private bool isDashButtonDown;

    private Vector3 moveDir;
    private Vector2 dodgeVect;

    public float invincibleDuration = 0.5f;
    private float invincibleDone = 0;
    public bool invincible = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        GameObject go = GameObject.FindGameObjectWithTag("DashCoolDown");
        dashCoolDown = go.GetComponent<DashCoolDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible && Time.time > invincibleDone)
        {
            invincible = false;
        }

        float aX = Input.GetAxis("Horizontal");
        float aY = Input.GetAxis("Vertical");

        //rigid.velocity = (new Vector2(aX, aY)).normalized * speed;

        moveDir = (new Vector3(aX, aY)).normalized;

        Vector2 movement = new Vector2(aX, aY);

        //PlayerMove();

        //if (speed <= 0)
        //{
        //    moving = false;
        //}

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDash && movement != Vector2.zero)
        {
            isDashButtonDown = true;
            //dodgeVect = movement.normalized;
            //dashCoolDown.coolingDown = true;
            //nextDash = Time.time + dashCoolDownTime;
            ////rigid.velocity = dodgeVect.normalized * dashSpeed;
            //transform.position += moveDir * dashSpeed * Time.deltaTime;
            //invincible = true;
            //invincibleDone = Time.time + invincibleDuration;
            //StaminaBar.s_instance.UseStamina(25);
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = moveDir * speed;
        
        if (isDashButtonDown)
        {
            rigid.MovePosition(transform.position + moveDir * dashSpeed);
            isDashButtonDown = false;
        }
    }

    //public void PlayerMove()
    //{
    //    float aX = Input.GetAxis("Horizontal");
    //    float aY = Input.GetAxis("Vertical");

    //    rigid.velocity = (new Vector2(aX, aY)).normalized * speed;

    //    moving = true;
    //}
}
