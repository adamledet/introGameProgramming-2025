using UnityEngine;

public class Detection : MonoBehaviour, IDetector
{
    IStealth character;
    [SerializeField] GameObject redMarker;
    [SerializeField] int health;
    [SerializeField] Animator animator;
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
        if(character != null)
        {
            if (!character.IsHidden()) detected = true;
            if(IsInFOV())
            {
                var direction = character.getTransform().position - transform.position;
                Debug.DrawRay(new Vector3(transform.position.x, 1, transform.position.z), direction, Color.red);
                var ray = new Ray(transform.position, direction);
                if (Physics.Raycast(ray, out RaycastHit hit/*,2*/))
                {
                    var stealth = hit.transform.GetComponent<IStealth>();
                    if (stealth != null) { detected = true; }
                }
            }
        }
    }

    bool IsInFOV()
    {
        return ((Vector3.Angle(transform.forward, character.getTransform().position - transform.position)) < 60);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TRIGGER ENTER");
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

    public void GetHit()
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
