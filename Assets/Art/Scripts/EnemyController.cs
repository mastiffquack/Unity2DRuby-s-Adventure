using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical) {
            position.y = position.y + Time.deltaTime * speed;
        } else {
            position.x = position.x + Time.deltaTime * speed;
        }

        rigidbody2D.MovePosition(position);
    }
    /*
     * Just like we used OnTriggerEnter2D, we can also use OnCollisionEnter2D, which is called when a Rigidbody collides with something. In this case, OnCollisionEnter2D is called when our enemy collides with the world or our main character. And just like we did for the damage zone, we can test to see if the enemy has collided with our main character. To do this, we check whether the GameObject that the enemy collided with has got a RubyController script. If it has, then we know it’s the main character, so we can damage it:
     * 
     */
    void OnCollisionEnter2D(Collision2D other) {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
