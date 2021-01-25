using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMapping : MonoBehaviour
{
    void Start()
    {
        Camera camera = Camera.main;
        float height = camera.orthographicSize * 2;
        float width = camera.aspect * height;

        transform.localScale = new Vector3(width, height, 1);
    }
}
