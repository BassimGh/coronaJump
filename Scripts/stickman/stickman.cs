using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Subsystems;

public class stickman : MonoBehaviour
{
    Rigidbody2D rb;

    public Camera mainCamera;
    public Animator animator;
    public ParticleSystem fallen;
    public ParticleSystem boom;
    public GameObject explode;

    public float sensitivity = 10f;
    public bool control = true;
    public float bigJumpForce;
    public int angle = 0;
    public float delay = 4f;

    public bool started = false;
    public bool died = false;
    bool infected = false;
    float x1;
    float x2;
    float y1;
    float y2;

    private void Awake()
    {
        fallen.Pause();
        boom.Pause();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator bigjump()
    {
        started = true;
        FindObjectOfType<GameManager>().StartGame();
        animator.SetBool("bigJump", true);
        yield return new WaitForSeconds(1);
        rb.AddForce(Vector3.up * bigJumpForce);
    }

    private void FixedUpdate()
    {
        float xmovement = Input.GetAxis("Horizontal");
        if (control) rb.velocity = new Vector3(xmovement * sensitivity, rb.velocity.y, 0);
        
    }
    private void Update()
    {
        y2 = transform.position.y;

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !started) StartCoroutine(bigjump());

        //float mouseposx = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
        //if(transform.position.y > 10 && control) transform.position = new Vector3(mouseposx, transform.position.y, 0);

        //----------Facing rotation--------------
        x2 = transform.position.x;
        if (x2 - x1 > 0.1) angle = 180;
        if (x2 - x1 < -0.1) angle = 0;

        if (control) transform.rotation = Quaternion.Euler(0, angle, 0);
        x1 = x2;

        //-----------Bend Knees------------------
        
        if (y2 - y1 < 0 & transform.position.y > 5) animator.SetBool("BendKnees", true);
        if (y2 - y1 >= 0 & transform.position.y > 5) animator.SetBool("BendKnees", false);
        y1 = y2;

        //----------Death Effects-----------------

        if (transform.position.y - mainCamera.transform.position.y + 10.8 < 0 && died == false)
        {
            fallen.Play();
            rb.simulated = false;
            died = true;
            FindObjectOfType<GameManager>().EndGame();
        }
        boom.transform.parent = gameObject.transform;
        //-----------Infected-----------------------
        if (infected) Infected();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetBool("Landed", true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        animator.SetBool("Landed", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //-----------------STICKY MUCUS----------------------------------------
        foreach (Collider2D c in GetComponentsInChildren<Collider2D>())
        {
            if (collision.IsTouching(c))
            {
                GameObject touching = c.gameObject;
                if(collision.gameObject.name == "mucus" || collision.gameObject.name == "mucus(Clone)" & delay > 0)
                {
                    collision.GetComponent<Rigidbody2D>().simulated = false;
                    collision.transform.parent = touching.transform;
                    infected = true;
                }
            }
        }
        //-----------------------------------------------------------------------
    }
    void Infected()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in sprites) s.color = Color.Lerp(s.color, Color.green, 0.1f);
        if (GetComponentInChildren<SpriteRenderer>().color == Color.green)
        {
            foreach (GameObject mucus in GameObject.FindGameObjectsWithTag("germ"))
            {
                mucus.transform.parent = null;
                mucus.GetComponent<Rigidbody2D>().simulated = true;
            }
            control = false;
            //explode.SetActive(true);   <----- force field
            boom.transform.parent = null;
            boom.Play();
            Destroy(gameObject);
        }
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            //
        }
    }
}
