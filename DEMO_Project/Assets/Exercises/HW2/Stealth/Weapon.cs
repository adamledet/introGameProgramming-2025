using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Collider myCollider;

    void OnTriggerEnter(Collider collider)
    {
        var detector = collider.GetComponent<IDetector>();
        detector?.GetHit();
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
