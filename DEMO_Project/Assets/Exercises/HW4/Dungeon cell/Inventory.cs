using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public class Inventory : MonoBehaviour
    {
        List<Item> items = new();

        internal void Add(Item activeItem)
        {
            items.Add(activeItem);
        }
    }
}
