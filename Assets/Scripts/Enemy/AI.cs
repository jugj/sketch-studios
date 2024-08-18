using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 4f; 
    public float detectionRange = 10f;
    public FieldOfView FoV;
    public Animator anim;
    public Rigidbody2D rb;
    public bool isFacingRight = true;
    public BoxScript damage;
    public float attackTimer;
    public float timer;
    bool canAttack = true;
    public GameObject attackCol;
    bool attacks;
    public AudioSource attackSound;

    void Update()
    {
        Flip();
        Animation();



        if(damage.gotHurt == false && damage.enemypause == false) 
        {
             if(FoV.CanSeePlayer) 
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.position);

             if (distanceToPlayer >= detectionRange)
                {
                    Vector2 direction = (player.position - transform.position).normalized;

                    rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

                }
                else 
                {
                   rb.velocity = Vector2.zero;

                   if(timer < 0 && canAttack) 
                   {
                        anim.SetTrigger("attack");
                        canAttack = false;
                   }
                   else 
                   {
                        timer -= Time.deltaTime;
                        canAttack = true;
                   }
                }
            }
            else 
            {
                rb.velocity = Vector2.zero;
            }
        }
        
       
        
        
    }

     void Flip() 
    { 
        if(rb.velocity.x > 0 && !isFacingRight || rb.velocity.x < 0 && isFacingRight) 
        {
            Vector3 Scale = transform.localScale;
            isFacingRight = !isFacingRight;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
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

    public void AttackCol() 
    {
        attackSound.Play();
        attackCol.SetActive(true);
    }

    public void AttackColDisable() 
    {
        attackCol.SetActive(false);
        timer = attackTimer;
    }

}
