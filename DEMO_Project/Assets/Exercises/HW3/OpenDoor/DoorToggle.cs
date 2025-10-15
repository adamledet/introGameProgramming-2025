using UnityEngine;

public class DoorToggle : MonoBehaviour
{

    bool open;
    [SerializeField] Animator animator;
    
    public void Toggle()
    {
        open = !open;
        animator.SetTrigger(open ? "Open" : "Close");
        Debug.Log("Attempt to Open/Close");
    }
}
