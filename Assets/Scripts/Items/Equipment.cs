using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int armorModifier;
    public int damageModifier;

    public int armorMod;
    public int damageMod;

    public EquipmentSlot type;

    public override void Use()
    {
        base.Use();
        //equip item
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        //remove from inventory
    }


    private void OnDisable()
    {
        armorModifier = armorMod;
        damageModifier = damageMod;
    }

}

public enum EquipmentSlot
{
    HEAD,
    CHEST,
    FEET,
    HANDS,
    SWORD
}