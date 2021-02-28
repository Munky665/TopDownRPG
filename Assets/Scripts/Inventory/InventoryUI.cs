using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    InventorySlot[] slots;
    Inventory inv;
    

    void Start()
    {
        inv = Inventory.instance;
        inv.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inv.items.Count)
            {
                slots[i].AddItem(inv.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        Debug.Log("Updating UI");
    }
}
