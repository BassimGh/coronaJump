using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float verticleForce;
    public float horizontalForce;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private IEnumerator Walljump()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<stickman>().control = false;
        animator.SetBool("walljump", true);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<stickman>().angle == 0) rb.velocity = new Vector3(1 * horizontalForce, 1 * verticleForce, 0);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<stickman>().angle == 180) rb.velocity = new Vector3(-1 * horizontalForce, 1 * verticleForce, 0);
        yield return new WaitForSeconds(0.6f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<stickman>().control = true;
        animator.SetBool("preWallJump", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(Walljump());
            //rb.AddForce(transform.up * verticleForce);
            //rb.velocity = new Vector3(rb.velocity.x, 1 * verticleForce, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag( "Player"))
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<stickman>().control = true;
        }
    }

}