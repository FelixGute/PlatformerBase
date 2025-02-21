using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 5f;
    float mDirection = 1;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(mDirection * velocity, 0);
    }

    public void Shoot(float direction)
    {
        mDirection = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
