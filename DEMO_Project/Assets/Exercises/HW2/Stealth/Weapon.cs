using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    [SerializeField] Animator animator;

    void OnTriggerEnter(Collider collider)
    {
        var detector = collider.GetComponent<IDetector>();
        detector?.GetHit(animator);
    }

    internal void Disable()
    {
        myCollider.enabled = false;
    }
    internal void Enable()
    {
        myCollider.enabled = true;
    }
}
