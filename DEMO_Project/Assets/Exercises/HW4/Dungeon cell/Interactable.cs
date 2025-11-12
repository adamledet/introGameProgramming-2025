using UnityEngine;


namespace Dungeon
{
    public class Interactable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PickupKey>(out PickupKey player))
            {
                player.isInRange();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PickupKey>(out PickupKey player))
            {
                player.OutsideRange();
            }
        }

        internal virtual void Interact(PickupKey player)
        {
            
        }
    }
}
