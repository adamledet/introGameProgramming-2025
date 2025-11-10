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
                if(!open)
                {
                    open = true;
                    animator.SetTrigger("Open");
                }
            }
            else
            {
                text.SetActive(true);
                text.GetComponent<TMPro.TextMeshProUGUI>().text = "Door is locked!";
            }
        }
    }
}
