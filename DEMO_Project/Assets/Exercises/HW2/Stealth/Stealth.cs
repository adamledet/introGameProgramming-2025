using Unity.VisualScripting;
using UnityEngine;

public class Stealth : MonoBehaviour, IStealth
{
    [SerializeField] Animator animator;
    bool crouching;
    Transform enemy;

    public bool IsHidden()
    {
        return crouching;
    }

    void Update()
    {
        if(enemy)
        {
            var dot = Vector3.Dot(transform.forward, enemy.position - transform.position);
            if(dot < 0 && dot > -0.5)
            {
                Debug.Log("DO THING");
            }
        }
    }

    public void OnCrouch()
    {
        crouching = !crouching;
        animator.SetBool("Crouching", crouching);
    }

    public void Notify(Transform enemy)
    {
        this.enemy = enemy;
    }
}
