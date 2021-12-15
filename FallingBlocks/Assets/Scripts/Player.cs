using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 7;


    private float WallLimit;
    private float velocity;
    private float halfPlayer;
    private int PlayerHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        halfPlayer = transform.localScale.x / 2f;
        WallLimit = Camera.main.aspect * Camera.main.orthographicSize - halfPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        velocity = speed * inputX;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        // Right wall limit
        if (transform.position.x > WallLimit)
            transform.position = new Vector2(WallLimit, transform.position.y);
        // Left Wall limit
        if (transform.position.x < -WallLimit)
            transform.position = new Vector2(-WallLimit, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (--PlayerHealth == 0)
            Destroy(this); 
    }
}
