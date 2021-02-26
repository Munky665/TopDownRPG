using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Potion", menuName ="Inventory/Potion")]
public class Potion : Item
{
    public float amountToRecover;
    public int healthOrMana;

    public override void Use()
    {
        base.Use();
        GameManager.instance.ItemUsedOnPlayer(this);
        RemoveFromInventory();
        
    }
}
