using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject[] enemyObj;
    public int deaths;


    void Start() 
    {
        deaths = 0;
    }

    void Update() 
    {
        foreach (GameObject Enemys in enemyObj) 
        {  
            BoxScript enemyscript = Enemys.GetComponent<BoxScript>();

            if(enemyscript.isDeadpublic) 
            {
                deaths++;
                enemyscript.isDeadpublic = false;
            }
        }

        if(deaths == enemyObj.Length) 
        {
            Destroy(this.gameObject);
            Debug.Log("win");
        } 
    }
}
