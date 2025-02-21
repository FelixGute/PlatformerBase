using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform groundCheck;
    bool isTouchingGround;
    public LayerMask groundMask;
    bool isFacingLeft = false;

    public Transform muzzle;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from player
        // Update velocity of the character based on input

        float direction = 0f;
        float playerSpeed = 5f;
        float jumpHeight = 8f;

        direction = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(direction * playerSpeed, rb.velocity.y);

        if (direction < 0f && !isFacingLeft)
        {
            isFacingLeft = true;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (direction > 0f && isFacingLeft)
        {
            isFacingLeft = false;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }


        if(Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
        

        // Jump:
        // Player presses button > character gets shot upwards
    }

    void Shoot()
    {
        if(muzzle.position.x < transform.position.x)
        {
            // Shoot left
            // Instansiate
            GameObject newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().Shoot(-1f);
        }
        else
        {
            // Shoot right
            GameObject newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().Shoot(1f);
        }
    }
}
