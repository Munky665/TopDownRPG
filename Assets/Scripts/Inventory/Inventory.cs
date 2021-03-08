using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    
    public int space = 20;
    public int healthPotions = 0;
    public int manaPotions = 0;

    public GameObject health;
    public GameObject mana;

    public Text manaText;
    public Text healthText;

    public List<Item> items = new List<Item>();
    public List<Item> potions = new List<Item>();

    public AudioClip sound;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            UseHealthPotion();
            
        }    
        if(Input.GetKeyDown(KeyCode.S))
        {
            UseManPotion();
        }
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough Room");
                return false;
            }
            
            items.Add(item);
            AddPotion(item);
    
            onItemChangedCallBack?.Invoke();

        }
        return true;
    }
    public void RemoveItem(Item item)
    {
        RemovePotion(item);
        potions.Remove(item);
        items.Remove(item);
        onItemChangedCallBack?.Invoke();
        MenuSFXManager.instance.PlaySound(item.sound);
    }

    void RemovePotion(Item item)
    {
        if (item is Potion)
        {
            var potion = item as Potion;
            if (potion.healthOrMana == 0)
            {
                if (healthPotions >= 1)
                {
                    healthPotions--;
                }
            }
            else if (potion.healthOrMana == 1)
            {
                if (manaPotions >= 1)
                {
                    manaPotions--;
                }
            }
        }

        manaText.text = manaPotions.ToString();
        healthText.text = healthPotions.ToString();
    }

    void AddPotion(Item item)
    {
        if (item is Potion)
        {
            var potion = item as Potion;
            if (potion.healthOrMana == 0)
            {
                healthPotions++;
            }
            else if (potion.healthOrMana == 1)
            {
                manaPotions++;
            }
        }

        potions.Add(item);
        manaText.text = manaPotions.ToString();
        healthText.text = healthPotions.ToString();
    }

    public void UseHealthPotion()
    {
        if (potions.Count > 0)
        {
            foreach (Item i in potions)
            {
                var potion = i as Potion;
                if (potion.healthOrMana == 0)
                {
                    i.Use();
                    MenuSFXManager.instance.PlaySound(sound);
                    break;
                }
            }
        }
        else
        {
            print("No Potions");
        }
    }

    public void UseManPotion()
    {
        if (potions.Count > 0)
        {
            foreach (Item i in potions)
            {
                var potion = i as Potion;
                if (potion.healthOrMana == 1)
                {
                    i.Use();
                    MenuSFXManager.instance.PlaySound(sound);
                    break;
                }
            }
        }
        else
        {
            print("No Potions");
        }
    }
}
