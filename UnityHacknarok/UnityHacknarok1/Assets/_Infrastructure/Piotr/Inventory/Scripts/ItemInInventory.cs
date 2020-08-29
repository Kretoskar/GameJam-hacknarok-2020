using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInInventory : MonoBehaviour
    
{
    [SerializeField] private int inventoryIndex;
    [SerializeField] private Dictionary<int, GameObject> ItemsKeyGameObject;
    [SerializeField] private Image itemInInventoryImage;
    void Start()
    {
        ItemsKeyGameObject = GetComponentInParent<Inventory>().ItemsKeyGameObject;
        itemInInventoryImage = GetComponent<Image>();
    }

    void Update()
    {
        if(ItemsKeyGameObject[inventoryIndex] != null)
        {
            itemInInventoryImage.sprite = ItemsKeyGameObject[inventoryIndex].GetComponent<SpriteRenderer>().sprite;
            
        }
    }
}
