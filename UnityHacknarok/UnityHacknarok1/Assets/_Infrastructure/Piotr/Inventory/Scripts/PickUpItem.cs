using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private ItemData ThisItemData;
    private ItemInInventory[] itemsInInventory;
    public AllocateSlots allocateSlots;

    private void Awake()
    {
        ThisItemData = GetComponent<DisplayItem>().ItemData;
        itemsInInventory = FindObjectsOfType<ItemInInventory>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("player"))
        {
            inventory.ItemsKeyGameObject.Add(ThisItemData.ItemID, gameObject);
            foreach(KeyValuePair<int, GameObject> item in inventory.ItemsKeyGameObject) // Nie mam odina, można wyjebać
            {
                inventory.itemsList.Add(item.Value.ToString());
            }
            UpdateItemDictionary();
        }
    }

    private void UpdateItemDictionary()
    {
        foreach(var item in itemsInInventory)
        {
            item.ItemsKeyGameObject = inventory.ItemsKeyGameObject;
            item.itemsKeys.Add(ThisItemData.ItemID);
        }
    }

}
