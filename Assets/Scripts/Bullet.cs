using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireSpeed = 7;

    private int Timer = 0;
    private static int MaxLifeTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer++;
        if (Timer == MaxLifeTime)
            Destroy(gameObject);
        transform.Translate(transform.up * fireSpeed);
    }
}
