using UnityEngine;

// Adam Ledet

// Attach to Equiment Item

public class PickupEquipment : MonoBehaviour
{
    [SerializeField] Sprite icon;
    [SerializeField] GameObject equippedObject;
    [SerializeField] string equipLocation;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<EquipmentManager>();
        if (player != null)
        {
            if(player.CanPickup())
            {
                player.PickupItem(equippedObject, icon, equipLocation);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Inventory Is Full!");
            }
        }
    }
}
