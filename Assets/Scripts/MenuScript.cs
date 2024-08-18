using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject InfoPanel;

    void Start() 
    {
        InfoPanel.SetActive(false);
    }

    public void Play() 
    {
        InfoPanel.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void Info() 
    {
        InfoPanel.SetActive(true);
    }

    public void Back() 
    {
        InfoPanel.SetActive(false);
    }
}
