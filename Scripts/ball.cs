using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    
    public Camera mainCamera;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        float mouseposx = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
        transform.position = new Vector3(mouseposx, transform.position.y, 0);
    }
    
}
