using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxMover : MonoBehaviour
{
    GameObject activeBox;
    bool movingBox;
    [SerializeField] Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveBox(GameObject box)
    {
        activeBox = box;
    }

    public bool IsMovingBox()
    {
        return movingBox;
    }

    public void OnInteract()
    {
        if (activeBox != null)
        {
            if(movingBox)
            {
                activeBox.transform.parent = null;
                movingBox = false;
                //GetComponent<Rigidbody>().freezeRotation = false;
            }
            else
            {
                movingBox = true;
                transform.LookAt(activeBox.transform);
                activeBox.transform.SetParent(transform);
                //GetComponent<Rigidbody>().freezeRotation = true;
            }
            animator.SetTrigger("Interact");
            GetComponent<ThirdPersonController>().attachedToBox = movingBox;
        }
    }
}
