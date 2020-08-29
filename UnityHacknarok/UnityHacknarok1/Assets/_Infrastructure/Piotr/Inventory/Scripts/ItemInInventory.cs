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
    public Component[] AllComponents;

    void Start()
    {
        ItemsKeyGameObject = GetComponentInParent<Inventory>().ItemsKeyGameObject;
        itemInInventoryImage = GetComponent<Image>();
        itemsKeys = new List<int>();
        HasBeenRemoved = false;
    }

    void Update()
    {
        if(allocateSlots.GetAvailableSlot() == inventoryIndex)
        {
            if(ItemsKeyGameObject.ContainsKey(inventoryIndex))
            {
                itemInInventoryImage.sprite = ItemsKeyGameObject[inventoryIndex].GetComponent<SpriteRenderer>().sprite;
                Destroy(ItemsKeyGameObject[itemsKeys[itemsKeys.Count - 1]]); // Destroy GameObject in ItemsKeyGameObject with key of last item added to itemKey List
                ItemsKeyGameObject.Remove(itemsKeys[itemsKeys.Count - 1]);
                allocateSlots.RemoveLowestSlot();
                UpdateComponents();
                IsOccupied = true;
            }
        }

    }

    public void RemoveItem()
    {
        //HasBeenRemoved = true;
        
        //allocateSlots.RearrangeAfterRemoved();

        //IsOccupied = false;
        //HasBeenRemoved = false;

        HasBeenRemoved = true;

        allocateSlots.RearrangeAfterRemoved();

        IsOccupied = false;
        HasBeenRemoved = false;
    }

    public void UpdateComponents()
    {
        AllComponents = GetComponents<Component>();
    }

}
