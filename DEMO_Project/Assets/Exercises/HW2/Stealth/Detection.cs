using UnityEngine;

public class Detection : MonoBehaviour, IDetector
{
    IStealth character;
    [SerializeField] GameObject redMarker;
    [SerializeField] int health;
    bool detected
    {
        get
        {
            return this;
        }
        set
        {
            redMarker.SetActive(value);
        }
    }

    void Update()
    {
        if(character != null && !detected)
        {
            detected = (IsInFOV() || !character.IsHidden());
        }
    }

    bool IsInFOV()
    {
        return ((Vector3.Angle(transform.forward, character.getTransform().position - transform.position)) < 60);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER");
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
        character = null;
        detected = false;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void GetHit(Animator animator)
    {
        Debug.Log("ENEMY HIT");
        if(health>0)
        {
            health -= 1;
            if (health == 0)
            {
                animator.SetTrigger("EnemyDead");
            }
            else { animator.SetTrigger("EnemyHit"); }
        }
    }

    public void Backstab()
    {
        return;
    }
}
