using UnityEngine;

public class EmoteWheel : MonoBehaviour
{

    [SerializeField] Animator animator;


    public void TauntEmote()
    {
        animator.SetTrigger("Taunt");
    }

    public void WaveEmote()
    {
        animator.SetTrigger("Wave");
    }
}
