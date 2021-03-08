using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    public AudioClip audio;
    Item item;
    

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log("remove " + item.name);
        Inventory.instance.RemoveItem(item);
        ClearSlot();
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            MenuSFXManager.instance.PlaySound(audio);
        }
    }
}
