using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Dungeon
{
    public class PickupKey : MonoBehaviour
    {
        [SerializeField] float range;
        [SerializeField] GameObject textPanel;
        private bool inRange;
        List<Item> items = new();
        private Interactable activeInteractable;

        private void Update()
        {
            if (inRange)
            {
                var item = Check();
                if(item != null)
                {
                    textPanel.SetActive(true);
                }
            }
            else if(activeInteractable)
            {
                activeInteractable = null;
                textPanel.SetActive(false);
            }
        }

        public void OnInteract()
        {
            if(activeInteractable)
            {
                activeInteractable.Interact(this);
            }
        }
        
        public void OpenDoor()
        {
            /*if(items.Contains())
            {
                
            }*/
        }

        public Interactable Check()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
            {
                return hit.transform.GetComponent<Interactable>();
            }
            return null;
        }

        internal void isInRange()
        {
            inRange = true;
        }
        internal void OutsideRange()
        {
            inRange = false;
        }
    }
}
