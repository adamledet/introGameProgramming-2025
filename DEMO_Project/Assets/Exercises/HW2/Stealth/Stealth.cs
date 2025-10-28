using Unity.VisualScripting;
using UnityEngine;

public class Stealth : MonoBehaviour, IStealth
{
    [SerializeField] Animator animator;
    [SerializeField] Weapon weapon;
    [SerializeField] bool crouching, canBackstab;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform backstabPos;
    IDetector enemy;
    [SerializeField] GameObject greenMarker;

    public bool IsCrouched()
    {
        return crouching;
    }

    void Update()
    {
        if(enemy != null)
        {
            var dot = Vector3.Dot(enemy.GetTransform().forward, transform.position - enemy.GetTransform().position);
            if (dot < -1 && enemy.IsUnaware())
            {
                canBackstab = true;
            }
            else
            {
                canBackstab = false;
            }
            greenMarker.SetActive(canBackstab);
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
            controller.enabled = false;
            transform.position = backstabPos.position;
            transform.forward = backstabPos.forward;
            animator.SetTrigger("Backstabbing");
            //var backstabPos = enemy;
        }
        else
        {
            animator.SetTrigger("Attacking");
        }
    }
    public void BackstabFinish()
    {
        controller.enabled = true;
    }

    public void StartAttack()
    {
        Debug.Log("START ATTACK");
        weapon.Enable();
    }
    public void StopAttack()
    {
        Debug.Log("STOP ATTACK");
        weapon.Disable();
    }

    public void Notify(IDetector enemy)
    {
        this.enemy = enemy;
    }

    public Transform getTransform()
    {
        return transform;
    }

    public void Backstab()
    {
        enemy.Backstab();
    }
}
