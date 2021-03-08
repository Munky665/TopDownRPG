using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public List<Item> possibleTypes;
    public AudioClip sound;

     private void Start()
    {
        if (item == null)
        {
            int type = Random.Range(0, 5);

            item = possibleTypes[type];
        }
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        bool pickUp = Inventory.instance.Add(item);

        if (pickUp)
        {
            Destroy(gameObject);
            MenuSFXManager.instance.PlaySound(sound);
        }
    }
}
