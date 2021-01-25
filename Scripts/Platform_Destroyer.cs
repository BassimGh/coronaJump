using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}