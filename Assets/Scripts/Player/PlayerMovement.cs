using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Vector2 movementDir;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isFacingRight = true;
    public float attackTime;
    bool canAttack = true;
    float timer;
    public GameObject attackCollider;
    float horizontal;
    float vertical;
    bool powerActive;
    public GameObject masks;
    public bool gotHurt;
    public float knockbackValue;
    public float knockbackTimer;
    float timer2;
    public int Health;
    bool canMove;
    AI enemy;
    public GameObject Rig;
    public Collider2D PlayerCol;
    public ParticleSystem deathParticle;
    bool died;
    public GameObject DeathPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = attackTime;
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "EnemyAttack") 
        {
            enemy = col.GetComponent<AI>();
            Damage(10);
            timer2 = knockbackTimer;
            gotHurt = true;
        }
    }

    void Damage(int damage) 
    {
        Health -= damage;
    }

    void Update()
    {
        if(timer2 <= 0) 
       {
            gotHurt = false;
       }
       else 
       {
            gotHurt = true;
            timer2 -= Time.deltaTime;
       }

       if(gotHurt) 
       {
            Knockback();
            canMove = false;
       }
       else 
       {
            canMove = true;
       }

       if(Health <= 0 && !died) 
       {
            Death();
            died = true;
       }
        
        GetInput();
        Flip();
        Animation();

        if(Input.GetButtonDown("Jump") && canAttack && !died) 
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

        if(Input.GetButtonDown("Power") && !powerActive) 
        {
            powerActive = true;
        }
        else if(Input.GetButtonDown("Power") && powerActive) 
        {
            powerActive = false;
        }

        if(powerActive) 
        {
            masks.SetActive(true);
        }
        else 
        {
            masks.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        if(canMove) 
        {
            rb.velocity = new Vector2(movementDir.x * speed, movementDir.y * speed);
        }
    }

    void GetInput() 
    {//
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movementDir = new Vector2(horizontal, vertical).normalized;
    }

    void Animation() 
    {
        if(horizontal != 0 || vertical != 0) 
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

      void Knockback() 
    {
        if(enemy.isFacingRight) 
        {
            rb.velocity = new Vector3(knockbackValue, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector3(-knockbackValue, rb.velocity.y);
        }
    }

    void Death() 
    {
        Rig.SetActive(false);
        PlayerCol.enabled = false;
        deathParticle.Play();
        DeathPanel.SetActive(true);
    }
   
}
