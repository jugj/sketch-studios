using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public bool powerActive;
    public GameObject masks;
    public AudioSource maskOn;
    public AudioSource maskOff;
    public AudioSource swordClash;
    
    public int Health;
    bool  canMove = true;
    AI enemy;
    public GameObject Rig;
    public Collider2D PlayerCol;
    public ParticleSystem deathParticle;
    bool died;
    public GameObject DeathPanel;
    public int maskHP = 10;
    public bool playerDead = false;
    bool isOver;
    private ManaBar manaBar;
    public GameObject ManaBar;
    public AudioSource footStep1;
    public AudioSource footStep2;
    public AudioSource healthSound;
    public  TMP_Text reasonText;
    public ParticleSystem collect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = attackTime;
        manaBar = ManaBar.GetComponent<ManaBar>();
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "EnemyAttack" && !powerActive) 
        {
            Damage(10);
            deathParticle.Play();
        }
        else if(col.gameObject.tag == "EnemyAttack" && powerActive) 
        {
            maskHP -= 2;
            manaBar.SetCurrentMana(manaBar.currentmana -= 2);
        }

        if(col.gameObject.tag == "powerHealth" && maskHP < 10) 
        {
            collect.Play();
            maskHP += 2;
            manaBar.SetCurrentMana(manaBar.currentmana += 2);
            Destroy(col.gameObject);
            healthSound.Play();
        }
    }

    void Damage(int damage) 
    {
        Health -= damage;
    }

    void Update()
    {

        if(powerActive && maskHP <= 0 && !isOver)
        {
            MaskExplode("Damage");
        }

       if(Health <= 0 && !died) 
       {
            Death();
            died = true;
       }
        if(!isOver) 
        {
            GetInput();
            Flip();
            Animation();

            if(Input.GetButtonDown("Jump") && canAttack && !died) 
            {
                anim.SetTrigger("attack");
                swordClash.Play();
                canAttack = false;
            }
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
            maskOn.Play();
            masks.SetActive(true);
        }
        else 
        {
            maskOff.Play();
            masks.SetActive(false);
        }
        if(Input.GetButtonDown("Jump") && powerActive)
        {
            MaskExplode("Sword");
        }
    }

    void FixedUpdate()
    {
        if(!isOver) 
        {
            rb.velocity = new Vector2(movementDir.x * speed, movementDir.y * speed);
        }
        else 
        {
            rb.velocity = Vector2.zero;
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

   public void MaskExplode(string reason)
   {
    if(!isOver) 
    {
        Death();
        Debug.Log("Player killed because of " + reason);
        reasonText.text = "Player killed because of " + reason;
        playerDead = true;
    }
   
   }
     

    void Death() 
    {
        isOver = true;
        Rig.SetActive(false);
        PlayerCol.enabled = false;
        deathParticle.Play();
        DeathPanel.SetActive(true);
    }
   
    public void Step1() 
    {
        if(!isOver) 
        {
            footStep1.Play();
        }
    }

    public void Step2() 
    {
        if(!isOver) 
        {
            footStep2.Play();
        }
    }
}
