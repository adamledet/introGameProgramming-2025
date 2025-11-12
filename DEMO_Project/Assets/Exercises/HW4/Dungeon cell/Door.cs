using UnityEngine;

namespace Dungeon
{
    public class Door : Interactable
    {
        [SerializeField] bool unlocked;
        [SerializeField] GameObject text;
        private bool open;
        [SerializeField] Animator animator;

        public void TryOpen()
        {
            if (unlocked)
            {
                OpenDoor();
            }
            else
            {
                text.SetActive(true);
                text.GetComponent<TMPro.TextMeshProUGUI>().text = "Door is locked!";
            }
        }

        private void OpenDoor()
        {
            animator.SetBool("OpenOutward", true);
        }

        private void CloseDoor()
        {
            animator.SetBool("OpenOutward", false);
        }

        protected void OnTriggerExit(Collider other)
        {
            if(open)
            {
                CloseDoor();
            }
        }
        
        /*internal override void Interact (Player player)
        {
            
        }*/
    }
}
