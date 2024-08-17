using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Vector2 movementDir;
    public Rigidbody2D rb;
    public Animator anim;
    bool isFacingRight = true;
    public float attackTime;
    bool canAttack = true;
    float timer;
    public GameObject attackCollider;
    float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = attackTime;
    }

    void Update()
    {
        GetInput();
        Flip();
        Animation();

        if(Input.GetButtonDown("Jump") && canAttack) 
        {
            anim.SetTrigger("attack");
            canAttack = false;
        }

        if(!canAttack) 
        {
            attackCollider.SetActive(true);
        }
        else 
        {
            attackCollider.SetActive(false);
        }

        if(!canAttack && timer > 0) 
        {
            timer -= Time.deltaTime;
        }
        
        else if(timer < 0 && !canAttack) 
        {
            timer = attackTime;
            canAttack = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDir.x * speed, movementDir.y * speed);
    }

    void GetInput() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDir = new Vector2(horizontal, vertical).normalized;
    }

    void Animation() 
    {
        if(rb.velocity.x != 0 || rb.velocity.y != 0) 
        {
            anim.SetFloat("speed", 1);
        }
        else 
        {
            anim.SetFloat("speed", 0);
        }
    }

    void Flip() 
    { 
        if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight) 
        {
            Vector3 Scale = transform.localScale;
            isFacingRight = !isFacingRight;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }

   
}
