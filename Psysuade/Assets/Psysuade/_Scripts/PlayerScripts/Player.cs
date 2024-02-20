using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    public float bulletSpeed = 20f;
    public float fireRate = 0;

    public float dashSpeed = 1f;
    public float dashCoolDownTime = 5f;
    private float nextDash;
    private DashCoolDown dashCoolDown;

    private float buttonCooler = 0.2f;
    private int buttonCount = 2;
    private int bPressed = 0;
    private int dodgeCount = 0;
    private Vector2 dodgeVect;

    //public int lives = 3;
    //public int maxLives = 3;

    //Shader
    Material material;
    //bool isDissolving = false;
    float fade = 1f;

    public GameObject bulletPrefab;
    public int maxHealth = 10;
    public float invincibleDuration = 0.5f;
    //public int weaponSelect = 0;
    private Rigidbody2D rigid;
    private float lastShot = 0.0f;
    private float invincibleDone = 0;
    public bool invincible = false;
    //AudioSource audioSource;

    public HealthBar healthBar;

    [SerializeField]
    private int _health;

    public int health
    {
        get { return _health; }
        set { _health = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameObject go = GameObject.FindGameObjectWithTag("DashCoolDown");
        dashCoolDown = go.GetComponent<DashCoolDown>();

        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible && Time.time > invincibleDone)
        {
            invincible = false;
        }

        //if (isDissolving)
        //{
        //    fade -= Time.deltaTime;
        //    if (fade <= 0)
        //    {
        //        fade = 0f;
        //        isDissolving = false;
        //    }

        //    material.SetFloat("_Fade", fade);
        //}

        //Old InputSystem
        float aX = Input.GetAxis("Horizontal");
        float aY = Input.GetAxis("Vertical");
        //Old InputSystem
        rigid.velocity = (new Vector2(aX, aY)).normalized * speed;
        Vector3 moveDir = (new Vector3(aX, aY)).normalized * speed;
        //Old InputSystem
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        //Controller Input
        float jX = Input.GetAxis("RightStickHorizontal");
        float jY = Input.GetAxis("RightStickVertical");
        Vector2 rightStickInput = new Vector2(jX, jY);
        if (rightStickInput.magnitude > 0f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.up * rightStickInput.y;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);
            rigid.SetRotation(playerRotation);
        }
        //fireRate = .5f;
        if (Input.GetAxis("RTFire") > 0)
        {
            RightTriggerFire();
        }
        //if (Time.time > fireRate + lastShot)
        //{
        //    GameObject go = Instantiate(bulletPrefab);
        //    go.transform.position = transform.position;
        //    Rigidbody2D rigidJoy = go.GetComponent<Rigidbody2D>();
        //    Destroy(go, 1.5f);
        //    rigidJoy.velocity = (new Vector2(jX, jY)).normalized * speed;
        //}
        
        //Old InputSystem
        Vector2 movement = new Vector2(aX, aY);
        //Dash Mechanic
        //Old InputSystem
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bPressed += 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Invoke("SetBPressedToZero", buttonCooler);
        }
        // bPressed > buttonCount - 1
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDash && movement != Vector2.zero)
        {
            dodgeVect = movement.normalized;
            dashCoolDown.coolingDown = true;
            nextDash = Time.time + dashCoolDownTime;
            //rigid.velocity = dodgeVect.normalized * dashSpeed;
            transform.position += moveDir * dashSpeed * Time.deltaTime;
            invincible = true;
            invincibleDone = Time.time + invincibleDuration;
            StaminaBar.s_instance.UseStamina(25);
        }
    }

    //Old InputSystem
    void SetBPressedToZero()
    {
        bPressed = 0;
    }

    //InputSystem
    void Fire()
    {
        fireRate = .5f;
        if (Time.time > fireRate + lastShot)
        {
            //audioSource = GetComponent<AudioSource>();
            GameObject go = Instantiate<GameObject>(bulletPrefab);
            go.transform.position = transform.position;
            Rigidbody2D rigidBullet = go.GetComponent<Rigidbody2D>();

            Destroy(go, 1.5f);
            //Old InputSystem
            Vector3 mPos = Input.mousePosition;
            mPos.z = -Camera.main.transform.position.z;
            Vector3 mPos3D = Camera.main.ScreenToWorldPoint(mPos);
            Vector3 dirToMouse = mPos3D - transform.position;
            dirToMouse.Normalize();

            rigidBullet.velocity = dirToMouse.normalized * bulletSpeed;
            lastShot = Time.time;
        }
    }
    void RightTriggerFire()
    {
        Vector2 bulletMove = Vector2.up * bulletSpeed * Time.deltaTime;
        fireRate = .5f;
        if (Time.time > fireRate + lastShot)
        {
            //audioSource = GetComponent<AudioSource>();
            GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
            go.transform.position = transform.position;
            //Rigidbody2D rigidBullet = go.GetComponent<Rigidbody2D>();

            Destroy(go, 1.5f);
            //Old InputSystem
            //Vector3 jPosx = Input.GetAxis("RightStickHorizontal"));
            // Vector3 jPos
            // mPos.z = -Camera.main.transform.position.z;
            //Vector3 mPos3D = Camera.main.ScreenToWorldPoint(mPos);
            //Vector3 dirToMouse = mPos3D - transform.position;
            // dirToMouse.Normalize();
            float jX = Input.GetAxis("RightStickHorizontal");
            float jY = Input.GetAxis("RightStickVertical");
            Vector2 rightStickInput = new Vector2(jX, jY);
            Vector3 rtPos = rightStickInput;
            //rtPos = Camera.main.transform.position;
            //Vector3 rtPos3D = Camera.main.ScreenToWorldPoint(rtPos);
            Vector3 dirToRT = -rtPos;
            dirToRT.Normalize();
            //rigidBullet.velocity = dirToMouse.normalized * bulletSpeed;
            //rigidBullet.velocity = dirToRT.normalized * bulletSpeed;
            lastShot = Time.time;
        }
    }

    void PlayerDissolve()
    {
        fade -= Time.deltaTime;
        if (fade <= 0)
        {
            fade = 0f;
            //isDissolving = false;
        }

        material.SetFloat("_Fade", fade);

        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (invincible) return;
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "EnemyShuriken")
        {
            Destroy(collidedWith);
            health -= 3;
            healthBar.SetHealth(health);
            invincible = true;
            invincibleDone = Time.time + invincibleDuration;
        }
        else if (collidedWith.tag == "Enemy")
        {
            health -= 2;
            healthBar.SetHealth(health);
            invincible = true;
            invincibleDone = Time.time + invincibleDuration;
        }

        //Deflecting
        //EnemyMagic
        //EnemyArrow
        //EnemySword

        if (health <= 0)
        {
            PlayerDissolve();
            //isDissolving = true;

            //Destroy(gameObject, 1);
        }
    }
}
