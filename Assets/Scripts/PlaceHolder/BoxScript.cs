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
    float timer;
    public int Health;
    public bool enemypause;
    public float enemypausetime;
    float pausetimer;

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
            Destroy(this.gameObject);
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
