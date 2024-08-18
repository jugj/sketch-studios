using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sword;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropSword();
        }
    }

    void DropSword()
    {
        if (sword != null)
        {
            sword.transform.position = transform.position;

            sword.transform.parent = null;

            Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }
}
