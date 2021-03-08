using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public Image[] images;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];

    }


    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.type;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];

            inventory.Add(oldItem);
            
        }

        onEquipmentChanged?.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;
        images[slotIndex].enabled = true;
        images[slotIndex].sprite = newItem.icon;

        if (oldItem == newItem)
        {
            newItem.armorModifier += oldItem.armorMod;
            newItem.damageModifier += oldItem.damageMod;
            inventory.RemoveItem(oldItem);
        }
        PlayerStatManager.instance.UpdateUI();
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
            images[slotIndex].enabled = false;
        }
    }

    public void UnequipAll ()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    //create update to check for input to remove all items
}
