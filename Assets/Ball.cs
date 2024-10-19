using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public ParticleSystem shiny;
    private float track = 0f;
    private float initialSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        startPosition = transform.position;
        Launch();
    }

    void Update() {
        track += Time.deltaTime;

        if (track > 5f) {
            speed += 0.5f;
            rb.velocity = rb.velocity.normalized * speed; // apply new speed but same direction
            Debug.Log("Speed increased to: " + speed);
            track = 0f;
        }
    }

    public void Reset() {
        speed = initialSpeed;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void Launch() {
        float x = Random.Range(0,2) == 0? -1 : 1;
        float y = Random.Range(0,2) == 0? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
        shiny.Play();
    }
}
