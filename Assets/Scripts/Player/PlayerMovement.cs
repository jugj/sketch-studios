using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Vector2 movementDir;
    Rigidbody2D rb;
    float vertical;
    float horizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movementDir = new Vector2(horizontal, vertical).normalized;

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDir.x * speed, movementDir.y * speed);
    }

   
}
