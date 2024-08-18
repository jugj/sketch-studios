using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSword : MonoBehaviour
{
    public GameObject otherSword;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer otherSwordRenderer;
    public int swordID = 1;
    private int otherSwordID;
    public GameObject AttackCol;
    public PlayerMovement player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        otherSwordRenderer = otherSword.GetComponent<SpriteRenderer>();
        otherSwordID = otherSword.GetComponent<ID>().swordID;
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Q))
            {
            if(otherSword.activeSelf)
            {

            float distance = Vector2.Distance(transform.position, otherSword.transform.position);

                	if (distance < 3f)
                {
                    if(player.powerActive) 
                    {
                        player.MaskExplode("Picked up a Sword");
                    }

                Color tempColor = spriteRenderer.color;
                spriteRenderer.color = otherSwordRenderer.color;
                otherSwordRenderer.color = tempColor;

                int swordIDBefore = swordID;
                swordID = otherSwordID;
                otherSwordID = swordIDBefore;

                Debug.Log("now holding sword ID " + swordID + " and droped sword ID " + otherSwordID);
                }
            }   
            }
        
       
        

        if(swordID == 1) 
        {
            AttackCol.tag = "PlayerAttack";
        }
        else if(swordID == 2) 
        {
            AttackCol.tag = "PlayerBuffedAttack";
        }
    }


}