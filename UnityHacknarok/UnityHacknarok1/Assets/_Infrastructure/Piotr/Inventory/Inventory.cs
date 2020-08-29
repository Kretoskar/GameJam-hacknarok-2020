using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, string> ItemsKeyName;
    public List<string> itemsList; //just for testing

    private void Awake()
    {
        ItemsKeyName = new Dictionary<int, string>();
    }



}
