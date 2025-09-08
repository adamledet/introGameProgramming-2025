using UnityEngine;

public class PickupEquipment : MonoBehaviour
{
    [SerializeField] Texture2D icon;
    [SerializeField] GameObject equippedObject;
    [SerializeField] string equipLocation;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<EquipmentManager>();
        if (player != null)
        {
            player.EquipItem(equippedObject, equipLocation);
        }
    }
}
