using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Item> items = new List<Item>();

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

            onItemChangedCallBack?.Invoke();

        }
        return true;
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        onItemChangedCallBack?.Invoke();
    }
}
