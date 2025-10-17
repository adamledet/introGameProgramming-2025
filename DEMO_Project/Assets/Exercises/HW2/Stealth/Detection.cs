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
        if(character)
        {
            detected = IsInFOV();
        }
    }

    bool IsInFOV()
    {
        return ((Vector3.Angle(transform.forward, character.getTransform().position - transform.position)) < 60);
    }

    private void OnTriggerEnter(Collider other)
    {
        var stealthy = other.GetComponent<IStealth>();
        if (stealthy)
        {
            character = stealthy;
            character.Notify(transform);
            if (!stealthy.IsHidden())
            {
                detected = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
