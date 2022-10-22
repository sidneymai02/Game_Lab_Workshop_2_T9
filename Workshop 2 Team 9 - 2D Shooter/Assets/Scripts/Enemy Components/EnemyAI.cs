using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    //public static event Action<Enemy> OnEnemyKilled;

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection = direction;
        }
    }

    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveSpeed);
        }
    }

    public void TakeDamage(float damageAmount)
    {

    }
}
