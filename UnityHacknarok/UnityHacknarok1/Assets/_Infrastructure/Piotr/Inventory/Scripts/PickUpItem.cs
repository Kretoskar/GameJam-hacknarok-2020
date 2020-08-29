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
            inventory.ItemsKeyGameObject.Add(ThisItemData.ItemID, this.gameObject);
            foreach(KeyValuePair<int, GameObject> item in inventory.ItemsKeyGameObject)
            {
                inventory.itemsList.Add(item.Value.ToString());
            }
            

        }
    }
}
