using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Floor : MonoBehaviour
{
    public float delta = 2f;
    public float speed = 2.0f;
    public float offset;
    private Vector3 startPos;
    private float random;
    void Start()
    {
        startPos = transform.position;
        random = Random.Range(0, 100);
    }

    void Update()
    {
        offset = random + Time.time;
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(offset * speed);
        transform.position = v;
        
    }
}
