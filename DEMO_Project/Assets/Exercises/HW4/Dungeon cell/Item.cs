using UnityEngine;

namespace Dungeon
{
    public class Item: Interactable
    {
        [SerializeField] GameObject visual;
        internal override void Interact(PickupKey player)
        {
            if(enabled)
            {
                //var inventory = player.GetInventory(player);
                //inventory.Add(this);
                Destroy(visual);
            }
        }

    }
}
