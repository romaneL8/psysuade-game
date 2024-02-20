using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectController : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 mousePos;
    public GameObject playerSword;
    public bool canDeflect;
    private float timer;
    public float timeBetweenDeflecting;
    public Rigidbody2D rb;

    private bool isDeflectButtonDown;

    //public Animator animator;

    public Transform deflectPoint;
    public float deflectRange = 0.5f;
    public LayerMask bulletLayers;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1)){
            isDeflectButtonDown = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 rotation = mousePos - rb.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (isDeflectButtonDown)
        {
            //Deflect
            Deflect();
        }
    }

    void Deflect()
    {
        //Implement IDeflectable

        //Play Deflect Animation
        //animator.SetTrigger("Deflect");

        //Detect Bullets in Deflect range
        Collider2D[] hitBullets = Physics2D.OverlapCircleAll(deflectPoint.position, deflectRange, bulletLayers);

        //Add Velocity to Deflected Bullets in Reverse Direction
        for (int i = 0; i < hitBullets.Length; i++)
        {
            IDeflectable iDeflectable = hitBullets[i].GetComponent<Collider2D>().gameObject.GetComponent<IDeflectable>();

            if (iDeflectable != null)
            {
                iDeflectable.Deflect(transform.right);
            }
        }
    }
}
