using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 4f; 
    public float detectionRange = 10f;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

         if (distanceToPlayer <= detectionRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;

                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
    }
}
