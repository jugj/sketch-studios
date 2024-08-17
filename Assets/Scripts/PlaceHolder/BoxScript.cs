using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public ParticleSystem particle;
    PlayerMovement player;
    Rigidbody2D rb;
    bool gotHurt;
    public float knockbackValue;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "PlayerAttack") 
        {
            particle.Play();
            Debug.Log("Trigger");
            Knockback();
            gotHurt = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        if(col.gameObject.tag == "PlayerAttack") 
        {
            gotHurt = false;
        } 
    }

    void Update() 
    {
        if(!gotHurt) 
        {
            rb.velocity = Vector2.zero;
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
