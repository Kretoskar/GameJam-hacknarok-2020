using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private ItemData ThisItemData;

    private void Start()
    {
        ThisItemData = GetComponent<DisplayItem>().ItemData;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("player"))
        {
            inventory.ItemsKeyName.Add(ThisItemData.ItemID, ThisItemData.ItemName);
            foreach(KeyValuePair<int, string> item in inventory.ItemsKeyName)
            {
                inventory.itemsList.Add(item.Value);
            }
            Debug.Log("collision");
        }
    }
}
