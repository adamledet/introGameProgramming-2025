using UnityEngine;

public class Detection : MonoBehaviour, IDetector
{
    IStealth character;
    [SerializeField] GameObject redMarker;
    bool detected
    {
        set
        {
            redMarker.SetActive(value);
        }
    }

    void Update()
    {
        if(character != null)
        {
            detected = IsInFOV() || !character.IsHidden();
        }
    }

    bool IsInFOV()
    {
        return ((Vector3.Angle(transform.forward, character.getTransform().position - transform.position)) < 60);
    }

    private void OnTriggerEnter(Collider other)
    {
        var stealthy = other.GetComponent<IStealth>();
        if (stealthy != null)
        {
            character = stealthy;
            character.Notify(this);
            if (!stealthy.IsHidden())
            {
                detected = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void GetHit()
    {
        return;
    }

    public void Backstab()
    {
        return;
    }
}
