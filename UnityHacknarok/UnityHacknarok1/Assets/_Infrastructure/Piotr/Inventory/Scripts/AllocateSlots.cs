using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AllocateSlots : MonoBehaviour
{
    public List<int> AvailableSlots;
    public int AvailableSlot;
    public int MaxSlots;
    public ItemInInventory[] ItemsInInventory;
    public Dictionary<int, int> OldIndexNewIndex;
    private void Awake()
    {
        AvailableSlot = 0;
        AvailableSlots = new List<int> { 0, 1, 2 };

    }

    public void UpdateAvailableSlot()
    {
        AvailableSlot++;
    }

    public int GetAvailableSlot()
    {
        if(AvailableSlots.Count != 0)
        {
            AvailableSlot = AvailableSlots.Min();
            return AvailableSlot;
        }

        return 5;
        
    }

    public void RemoveLowestSlot()
    {
        AvailableSlots.Remove(AvailableSlot);
    }

    public void RearrangeAfterRemoved()
    {
        foreach (var item in ItemsInInventory)
        {
            if (item.HasBeenRemoved)
            {
                if (item.inventoryIndex == 0)
                {
                    item.transform.SetSiblingIndex(2);
                }
                else if (item.inventoryIndex == 1)
                {
                    item.transform.SetSiblingIndex(2);
                }
                item.GetComponent<Image>().sprite = null;
            }
        }
    }
}
