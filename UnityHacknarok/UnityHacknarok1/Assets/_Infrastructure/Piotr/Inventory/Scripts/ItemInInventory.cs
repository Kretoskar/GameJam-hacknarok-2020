using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInInventory : MonoBehaviour
    
{
    [SerializeField] public int inventoryIndex;
    public Dictionary<int, GameObject> ItemsKeyGameObject;
    [SerializeField] private Image itemInInventoryImage;
    public List<int> itemsKeys; // Contains all item keys in inventory
    public int itemKey; // Contains stored item key
    public AllocateSlots allocateSlots;
    public bool HasBeenRemoved;
    public bool IsOccupied = false;

    void Start()
    {
        ItemsKeyGameObject = GetComponentInParent<Inventory>().ItemsKeyGameObject;
        itemInInventoryImage = GetComponent<Image>();
        itemsKeys = new List<int>();
        HasBeenRemoved = false;
    }

    void Update()
    {
        if(allocateSlots.GetAvailableSlot() == inventoryIndex && ItemsKeyGameObject != null)
        {
            if(ItemsKeyGameObject.ContainsKey(itemKey))
            {

                itemInInventoryImage.sprite = ItemsKeyGameObject[itemKey].GetComponent<SpriteRenderer>().sprite;
                itemKey = itemsKeys[itemsKeys.Count - 1];
                Destroy(ItemsKeyGameObject[itemKey]); // Destroy GameObject in ItemsKeyGameObject with key of last item added to itemKey List
                ItemsKeyGameObject.Remove(itemsKeys[itemsKeys.Count - 1]);
                allocateSlots.RemoveLowestSlot();
                IsOccupied = true;
            }
        }
        inventoryIndex = transform.GetSiblingIndex();
    }

    public int RemoveItem() // zmień to na metodę zwracającą inta, która za parametr przyjmuje id
    {
        int key = itemKey;
        HasBeenRemoved = true;
        allocateSlots.RearrangeAfterRemoved();
        IsOccupied = false;

        
        HasBeenRemoved = false;
        return key;
    }
}
