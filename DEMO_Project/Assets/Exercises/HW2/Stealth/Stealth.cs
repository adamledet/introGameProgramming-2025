using Unity.VisualScripting;
using UnityEngine;

public class Stealth : MonoBehaviour, IStealth
{
    [SerializeField] Animator animator;
    bool crouching, canBackstab;
    Transform enemy;

    public bool IsHidden()
    {
        return crouching;
    }

    void Update()
    {
        if(enemy != null)
        {
            var dot = Vector3.Dot(transform.forward, enemy.position - transform.position);
            if (dot < 0 && dot > -0.5)
            {
                canBackstab = true;
            }
            else
            {
                canBackstab = false;
            }
        }
    }

    public void OnCrouch()
    {
        crouching = !crouching;
        animator.SetBool("Crouching", crouching);
    }

    public void OnAction()
    {
        if (canBackstab)
        {
            // Backstab
        }
        else
        {
            // Attack
        }
    }

    public void Notify(IDetector enemy)
    {
        this.enemy = enemy.GetTransform();
    }

    public Transform getTransform()
    {
        return transform;
    }
}
