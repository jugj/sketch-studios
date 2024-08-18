using UnityEngine;
using System.Collections;

public class SonicSpeed : MonoBehaviour
{
    public bool maskOn = false;
    public float launchDistance = 5f;
    public float launchDuration = 0.5f;
    private bool isLaunching = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(maskOn){
            if (Input.GetKeyDown(KeyCode.Y) && !isLaunching)
            {
                StartCoroutine(Launch());
            }
        }
    }

    private IEnumerator Launch()
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
        isLaunching = false;
    }
}
