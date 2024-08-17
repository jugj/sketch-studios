using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class Spaceship : MonoBehaviour
{
   public float Geschwindigkeit;

  public int maxmana = 10;
  public int currentmana;

  public ManaBar manabar;

    // Start is called before the first frame update
    void Start()
    {

        currentmana = maxmana;
        manabar.SetMaxMana(10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
      transform.Translate(Vector2.up*Geschwindigkeit*Time.deltaTime,Space.World);

        if(Input.GetKey("a"))
      transform.Translate(Vector2.left*Geschwindigkeit*Time.deltaTime,Space.World);

        if(Input.GetKey("s"))
      transform.Translate(Vector2.down*Geschwindigkeit*Time.deltaTime,Space.World);

        if(Input.GetKey("d"))
      transform.Translate(Vector2.right*Geschwindigkeit*Time.deltaTime,Space.World);
        
        if(Input.GetKey("x")){
        currentmana -=1;
         manabar.SetCurrentMana (currentmana);
        }

        if(Input.GetKey("r")){
        currentmana +=1;
         manabar.SetCurrentMana (currentmana);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //reduce mana by 1
        currentmana -=1;
        manabar.SetCurrentMana (currentmana);
        Destroy(other.gameObject);
    }
}
