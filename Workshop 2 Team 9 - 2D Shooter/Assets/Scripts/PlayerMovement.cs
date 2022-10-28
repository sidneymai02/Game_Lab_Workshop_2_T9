using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    private Vector2 movement;
    private Vector2 mousePos;

    public GameObject topRightLimitGameObject;
    public GameObject bottomLeftLimitGameObject;

    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;

    public GameObject[] lives;
    public int life;
    private bool dead = false; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        topRightLimit = topRightLimitGameObject.transform.position;
        bottomLeftLimit = bottomLeftLimitGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Debug.Log("You are dead!");
            EndGame();
        }
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void EndGame()
    {
        Application.Quit();
    }

    void FixedUpdate()
    {
        

        if ((transform.position.x <= bottomLeftLimit.x && movement.x == -1) || (transform.position.x >= topRightLimit.x && movement.x == 1))
        {
            movement.x = 0;
        }
        if ((transform.position.y <= bottomLeftLimit.y && movement.y == -1) || (transform.position.y >= topRightLimit.y && movement.y == 1))
        {
            movement.y = 0;
        }
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                TakeDamage();
                break;
        }
    }

    public void TakeDamage()
    {
        if (life >= 1)
        {
            life--;
            Destroy(lives[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }

}
