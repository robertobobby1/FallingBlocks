using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    public Vector2 SpeedMinMax;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp( SpeedMinMax.x, SpeedMinMax.y, Difficulty.getDifficultyPercentage());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.down * speed * Time.deltaTime);
    }
}
