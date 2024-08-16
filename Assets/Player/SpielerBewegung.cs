using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerBewegung : MonoBehaviour
{
    public Rigidbody2D rb;

    public float gravityScale = 0.0f;
    public float fallingGravityScale = 15.0f;
    private bool istInDerLuft = false;

    public float SprungKraft = 30.0f;

    public float Geschwindigkeit = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

    }


    //Wird alle 50 Frames aktiviert. Alles was mit Physik zu tun hat, macht man hier.
    void FixedUpdate()
    {
        //Laufen
        if (Input.GetKey("right"))
        {
            Debug.Log("rechts");
            rb.AddForce(Vector2.right * Geschwindigkeit, ForceMode2D.Impulse);
        }
        if (Input.GetKey("left"))
        {
            Debug.Log("links");
            rb.AddForce(Vector2.left * Geschwindigkeit, ForceMode2D.Impulse);
        }


        //Springen // Für mehr Tipps und andere Techniken, wie man in Unity springen kann: https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/
        if (rb.velocity.y == 0.0f)
        {
            istInDerLuft = false;
        }

        //Wenn die Pfeiltaste Oben runter gedrückt wird und der Spieler nicht in der Luft ist, springt der Spieler
        if (Input.GetKey("up") && !istInDerLuft)
        {
            rb.AddForce(Vector2.up * SprungKraft, ForceMode2D.Impulse);
            istInDerLuft = true;
        }


        //Schneller Fallen. Wie bei Super Mario. Der Einfluss der Schwerkraft auf den Charakter wird geändert, je nachdem, ob er sich gerade nach Oben, oder nach Unten bewegt.
        if (rb.velocity.y >= 0.0f)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0.0f)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Debug.Log("The Player hit a Platform");
            istInDerLuft = false;
        }
        else
        {
            Debug.Log("Something collided with the Player");
        }
    }

    //private void OnTriggerEnter2D(Collision2D other) {
    //    Debug.Log($"Something collided with the Player");;
    //}


    //Alle Keycodes findest du hier: https://docs.unity3d.com/ScriptReference/KeyCode.html
}
