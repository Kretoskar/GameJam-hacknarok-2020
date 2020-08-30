using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    private static Inventory _instance;

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Inventory>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("Inventory");
                    _instance = container.AddComponent<Inventory>();
                }
            }

            return _instance;
        }
    }
        

    #endregion
    
    public Dictionary<int, GameObject> ItemsKeyGameObject;
    public GameObject[] inventorySlots;
    public List<string> itemsList; //just for testing


    private void Start()
    {
        ItemsKeyGameObject = new Dictionary<int, GameObject>();
    }

    public bool IsIdInInventory(int id)
    {
        foreach(var slot in inventorySlots)
        {
            if(slot.GetComponent<ItemInInventory>().itemKey == id)
            {
                return true;
            }
        }
        return false;
    }

    public int? GetItemById(int id)
    {
        foreach(var slot in inventorySlots)
        {
            if(slot.GetComponent<ItemInInventory>().itemKey == id)
            {
                return slot.GetComponent<ItemInInventory>().RemoveItem(id);
            }
        }

        return null;
    }

}
