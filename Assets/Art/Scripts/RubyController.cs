using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // ========= MOVEMENT =================
    public float speed = 4;

    // ======== HEALTH ==========
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    // ======== HEALTH ==========
    public int health 
    {
        get { return currentHealth; }
    }

    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;

    // ======== HEALTH ==========
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;

    // ==== ANIMATION =====
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    void Start()
    {
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();

        // ======== HEALTH ==========
        currentHealth = maxHealth;

        currentHealth = 1;

        // ==== ANIMATION =====
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ================= HEALTH ====================
        if (isInvincible) {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        // ============== MOVEMENT ======================
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        // ============== ANIMATION =======================

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

    }

    public void ChangeHealth(int amount) 
    {
        if (amount < 0) {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
