using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, GameObject> ItemsKeyGameObject;
    public List<string> itemsList; //just for testing
    public ItemData[] allItems;

    private void Awake()
    {
        ItemsKeyGameObject = new Dictionary<int, GameObject>();
        allItems = FindObjectsOfType<ItemData>();

    }



}
