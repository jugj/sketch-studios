using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public ParticleSystem particle;

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "PlayerAttack") 
        {
            particle.Play();
            Debug.Log("Trigger");
        }
    }

   
}
