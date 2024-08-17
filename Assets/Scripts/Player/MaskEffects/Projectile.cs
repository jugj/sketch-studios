using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private float lifetime = 3f;
    private float timer;

    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")){
        Destroy(gameObject);
        }
    }
}
