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
    bool detected;//The 'set' caused stackoverflow. Was unable to fix, so used standard bool

    void Start()
    {
        maxHp = health;
    }

    void Update()
    {
        if(character != null && !detected)
        {
            detected = (IsInFOV() || !character.IsCrouched());
            //Debug.Log($"In FOV: {IsInFOV()}, !IsCrouched: {!character.IsCrouched()}, detected: {detected}");
        }
        redMarker.SetActive(detected);//I don't like setting this at every update, but it works.
    }

    public bool IsUnaware()
    {
        return !detected;
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
            //Debug.Log("TRIGGER ENTER");
            character = stealthy;
            character.Notify(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var stealthy = other.GetComponent<IStealth>();
        if (stealthy != null)
        {
            detected = false;
            character.Notify(null);
            character = null;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void GetHit()
    {
        //Debug.Log("ENEMY HIT");
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
