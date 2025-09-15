using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Adam Ledet

// Attach to player

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] List<GameObject> headEquip;
    [SerializeField] List<GameObject> chestEquip;
    [SerializeField] List<GameObject> handEquip;
    [SerializeField] List<GameObject> backEquip;

    [SerializeField] List<GameObject> inventory;
    [SerializeField] GameObject inventoryDisplay;
    [SerializeField] int listEntry;
    [SerializeField] int listMax;

    public void Start()
    {
        listMax = inventoryDisplay.transform.childCount;// Set the max number of inventory spaces to the number of 'slot' objects
    }

    public void PickupItem(GameObject item, Sprite icon, string location)
    {

        // Make it so the Cursor isn't locked so the user can select equipment by clicking.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (listEntry < listMax)
        {
            inventory.Add(item);
            var slot = inventoryDisplay.transform.GetChild(listEntry);
            slot.GetComponent<Image>().sprite = icon;
            slot.GetComponent<InventoryManager>().equipment = item;
            slot.GetComponent<InventoryManager>().location = location;
            slot.GetComponent<InventoryManager>().player = this.gameObject;
            listEntry += 1;
        }
        else
        {
            Debug.Log("Trying to Pickup while Inventory is Full!");// Called only if player attempts to pickup an item while inventory is full. 'CanPickup()' should catch this case.
        }
    }

    // Helper Function called by PickupEquipment
    public bool CanPickup()
    {
        if (listEntry < listMax) { return true; }
        else { return false; }
    }

    // Unequip all items that are currently equipped to a given slot. Called when equipping an item to an existing slot by InventoryManager
    public void UnequipSlot(string location)
    {
        if(location.ToLower() == "head")
        {
            UnequipAll(headEquip);
        }
        else if(location.ToLower() == "chest")
        {
            UnequipAll(chestEquip);
        }
        else if (location.ToLower() == "hand")
        {
            UnequipAll(handEquip);
        }
        else if (location.ToLower() == "back")
        {
            UnequipAll(backEquip);
        }
        else
        {
            Debug.Log($"Attempted to Uniequip a Slot that Does not Exist: {location}");
        }
    }

    // Helper function for UnequipSlot
    private void UnequipAll(List<GameObject> equipList)
    {
        foreach (GameObject item in equipList)
        {
            item.SetActive(false);
        }
    }
}
