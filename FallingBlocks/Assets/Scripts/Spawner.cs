using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float secondsBetweenSpawns = 1;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    float nextSpawnTime;

    Vector2 screenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time < nextSpawnTime) { 
            return;
        }
        // Debug.Log(Time.time);
        // size of block
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        // position of block
        Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize/2f);
        // direction of block (z-axis)
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);


        GameObject fallingBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler (Vector3.forward * spawnAngle));
        fallingBlock.transform.localScale = Vector2.one * spawnSize;

        // increment timer
        nextSpawnTime = Time.time + secondsBetweenSpawns;
    }
}
