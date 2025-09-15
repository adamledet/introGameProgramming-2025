using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// Adam Ledet

// Attach to Inventory UI

public class InventoryManager : MonoBehaviour
{
    // Attributes are public because they are written to when an item is added to the slot
    public GameObject equipment;
    public string location;
    public GameObject player;

    public void EquipItem()
    {
        if (equipment != null)
        {
            // If clicking when equipment is already active, unequip it
            if (equipment.activeSelf)
            {
                equipment.SetActive(false);
                return;
            }
            player.GetComponent<EquipmentManager>().UnequipSlot(location);
            equipment.SetActive(true);
        }
        else
        {
            Debug.Log("Item is not in Inventory Slot!");
        }
    }
}
