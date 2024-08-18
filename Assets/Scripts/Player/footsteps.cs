using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepSound;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) {
            footstepSound.Play();
        }
        else
        {
            footstepSound.Stop();
        }
    }
}