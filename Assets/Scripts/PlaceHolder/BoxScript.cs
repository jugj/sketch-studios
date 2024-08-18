using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public ParticleSystem particle;
    PlayerMovement player;
    Rigidbody2D rb;
    public bool gotHurt;
    public float knockbackValue;
    public float knockbackTimer;
    public float knockbackTimerbuffed;
    float timer;
    public int Health;
    public bool enemypause;
    public float enemypausetime;
    float pausetimer;
    public bool isDead;
    public bool isDeadpublic;
    bool wasdead;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "PlayerAttack") 
        {
            Damage(10);
            particle.Play();
            Debug.Log("Trigger");
            timer = knockbackTimer;
            gotHurt = true;
        }

        if(col.gameObject.tag == "PlayerBuffedAttack") 
        {
            Damage(20);
            particle.Play();
            Debug.Log("Trigger");
            timer = knockbackTimerbuffed;
            gotHurt = true;
        }

        if(col.gameObject.tag == "BulletAttack") 
        {
            Damage(20);
            particle.Play();
        }
       
    }

    void Damage(int damage) 
    {
        Health -= damage;
    }


    void Update() 
    {
       if(timer <= 0) 
       {
            gotHurt = false;
       }
       else 
       {
            gotHurt = true;
            timer -= Time.deltaTime;
       }

       if(gotHurt) 
       {
            Knockback();
       }

       if(Health <= 0) 
       {
            isDead = true;
       }

        if(isDead && !wasdead) 
        {
            isDeadpublic = true;
            wasdead = true;
        }
      
    }


    void Knockback() 
    {
        if(player.isFacingRight) 
        {
            rb.velocity = new Vector3(knockbackValue, rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector3(-knockbackValue, rb.velocity.y);
        }
    }


   
}
