using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    GameObject player;
    public GameObject Floor;
    public float SpawnCount = 50f;
    public float minY = 1f;
    public float minY_Addition = 1f;
    public float maxY = 5f;
    public float LevelWidth = 8f;
    private Vector3 SpawnPos = new Vector3();
    private float posDiff = 0f;

    
    /*
    private float halfHeight = cam.orthographicSize;
    private float halfWidth = cam.aspect * halfHeight;

    private float horizontalMin = -halfWidth;
    private float horizontalMax =  halfWidth;
    */
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        posDiff = SpawnPos.y - player.transform.position.y;
        if (posDiff < 10)
        {
            minY += minY_Addition;
            Spawn();
        }
    }

    void Spawn()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        float horizontalMin = -halfWidth;
        float horizontalMax = halfWidth;

        for (int i = 0; i < SpawnCount; i++)
        {
            SpawnPos.x = Random.Range(horizontalMin, horizontalMax);
            SpawnPos.y += Random.Range(minY, maxY);

            Instantiate(Floor, SpawnPos, Quaternion.identity);
        }
    }
}
