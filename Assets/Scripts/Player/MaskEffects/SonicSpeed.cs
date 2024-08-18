using UnityEngine;
using System.Collections;

public class SonicSpeed : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovement playerMovement;    
    public float launchDistance = 8f;
    public float launchDuration = 0.2f;
    private bool isLaunching = false;
    private Rigidbody2D rb;
    private ManaBar manaBar;
    public GameObject ManaBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = Player.GetComponent<PlayerMovement>();
        manaBar = ManaBar.GetComponent<ManaBar>();
    }

    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Y) && !isLaunching)
            {
                    StartCoroutine(Launch());
            }
        
    }

    private IEnumerator Launch()
    {
        if(playerMovement.powerActive && playerMovement.maskHP > 1)
        {
            isLaunching = true;

            Vector2 launchDirection = Vector2.zero;

            while (launchDirection == Vector2.zero)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    launchDirection = Vector2.up;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    launchDirection = Vector2.left;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    launchDirection = Vector2.down;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    launchDirection = Vector2.right;
                }
                yield return null;

            }

            Vector2 startPosition = rb.position;
            Vector2 targetPosition = startPosition + launchDirection * launchDistance;

            float elapsedTime = 0f;

            while (elapsedTime < launchDuration)
            {
                rb.MovePosition(Vector2.Lerp(startPosition, targetPosition, (elapsedTime / launchDuration)));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rb.MovePosition(targetPosition);
            playerMovement.maskHP -= 2;
            manaBar.SetCurrentMana(manaBar.currentmana -= 2);
            Debug.Log("Mana left: " + playerMovement.maskHP);
            isLaunching = false;
        }
        else if(playerMovement.powerActive && playerMovement.maskHP <= 1)
            {
                playerMovement.MaskExplode("SonicSpeed");
            }
    }
}
