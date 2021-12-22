using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    public Vector2 SpeedMinMax;

    private float speed;
    private Vector2 MinMaxXaxis = new Vector2(-5.7f, 5.7f);
    private float YaxisLowBoundary = -4.5f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp( SpeedMinMax.x, SpeedMinMax.y, Difficulty.getDifficultyPercentage());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.down * speed * Time.deltaTime);

        if (transform.position.x > MinMaxXaxis.y
            || transform.position.x < MinMaxXaxis.x
            || transform.position.y < YaxisLowBoundary)
        { Destroy(gameObject);}
    }
}
