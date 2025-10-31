using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    private Vector3 direction;
    [SerializeField] float health;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position+=direction*speed*Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        var bullet = other.GetComponent<PlayerAttack>();
        if(bullet != null)
        {
            Debug.Log("HIT");
            bullet.health -= 1;
            TakeDamage(bullet.damage);
        }
    }

    private void TakeDamage(float damage)
    {
        health-= damage;
        if(health <= 0)
        {
            DestroySelf();
        }
    }
    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
