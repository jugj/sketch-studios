using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Close;
    public GameObject Open;
    public GameObject Sword2;
    public GameObject Player;
    public float openRadius = 3f;
    void Start()
    {
        Open.SetActive(false);
        Close.SetActive(true);
        Sword2.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(Input.GetKeyDown(KeyCode.Q) && distance <= openRadius){
            Open.SetActive(true);
            Close.SetActive(false);
            StartCoroutine(ActivateSwordAfterDelay());
        }
    }
    private IEnumerator ActivateSwordAfterDelay()
    {
        yield return new WaitForSeconds(1);
        Sword2.SetActive(true);
    }
}
