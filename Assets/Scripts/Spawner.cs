using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    public float MaxPunctuation;
   
    public ProgressBar Punctuation;

    private float nextSpawnTime;
    private bool heartsFilled;
    private float ActualPunctuation;
    Vector2 screenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        Punctuation.setMaxCounter(MaxPunctuation);
        Punctuation.setReverseProgressBar(true);
        heartsFilled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < nextSpawnTime) { 
            return;
        }
        // Set punctuation bar
        Punctuation.reduceAndUpdateCounter(1f);
        ActualPunctuation++;
        UpdateHearts();

        // size of block
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        // position of block
        Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize/2f);
        // direction of block (z-axis)
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

        GameObject fallingBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler (Vector3.forward * spawnAngle));
        fallingBlock.transform.localScale = Vector2.one * spawnSize;

        // Apply difficulty 
        float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.getDifficultyPercentage());

        // increment timer
        nextSpawnTime = Time.time + secondsBetweenSpawns;
    }

    private void UpdateHearts()
    {
        if (heartsFilled)
            return;

        float Percentage = ActualPunctuation / MaxPunctuation;
        GameObject Heart1 = Punctuation.transform.GetChild(2).gameObject;
        GameObject Heart2 = Punctuation.transform.GetChild(3).gameObject;

        if (Percentage >= (1f / 3f))
            Heart1.GetComponent<Image>().color = Color.red;

        if (Percentage >= (2f / 3f))
        {
            Heart2.GetComponent<Image>().color = Color.red;
            heartsFilled = true;
        }

    }
}
