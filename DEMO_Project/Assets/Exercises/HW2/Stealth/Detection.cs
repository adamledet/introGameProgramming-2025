using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour, IDetector
{
    IStealth character;
    [SerializeField] GameObject redMarker;
    [SerializeField] GameObject greenMarker;
    [SerializeField] int health;
    int maxHp;
    [SerializeField] Image healthbar;
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

    void Start()
    {
        maxHp = health;
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
        var stealthy = other.GetComponent<IStealth>();
        if (stealthy != null)
        {
            Debug.Log("TRIGGER ENTER");
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
                animator.SetBool("EnemyDead", true);
            }
            animator.SetTrigger("EnemyHit");
        }
        healthbar.fillAmount = (float)health / (float)maxHp;
    }

    public void Backstab()
    {
        animator.SetTrigger("Backstabbed");
    }
}
