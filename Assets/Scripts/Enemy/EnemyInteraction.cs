using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class EnemyInteraction : Interactable
{
    GameManager gM;
    CharacterCombat playerCombat;
    Stats myStats;

    private void Start()
    {
        gM = GameManager.instance;
        playerCombat = gM.player.GetComponent<CharacterCombat>();
        myStats = GetComponent<Stats>();
    }

    public override void Interact() 
    {
        print("Enemy Interaction triggered");
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
            playerCombat.GetComponent<PlayerController>().Attack();
            player.GetComponent<PlayerController>().StopMovmentAnim();
        }       
    }
}
