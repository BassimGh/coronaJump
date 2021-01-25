using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    public float jump_power = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb)
            {
                //contact = true;
                rb.velocity = new Vector3(rb.velocity.x, 1 * jump_power, 0);
                //rb.AddForce(transform.up * jump_power);
            }
        }
    }
}