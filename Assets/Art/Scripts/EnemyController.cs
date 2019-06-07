using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float timeToChange;
    public bool horizontal;

    Rigidbody2D rigidbody2d;
    float remainingTimeToChange;
    Vector2 direction = Vector2.right;

    // ===== ANIMATION ========
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        remainingTimeToChange = timeToChange;
        
        direction = horizontal ? Vector2.right : Vector2.down;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTimeToChange -= Time.deltaTime;

        if (remainingTimeToChange <= 0) {
            remainingTimeToChange += timeToChange;
            direction *= -1;
        }
        
        rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);

        animator.SetFloat("ForwardX", direction.x);
        animator.SetFloat("ForwardY", direction.y);
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
