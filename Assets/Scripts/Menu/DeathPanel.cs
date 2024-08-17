using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
   public void Restart() 
   {
        SceneManager.LoadScene("Game");
   }

   public void Menu() 
   {
        SceneManager.LoadScene("Menu");
   }
}
