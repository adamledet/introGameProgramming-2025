using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    private Vector3 direction;
    [SerializeField] float health;
    private float maxHP;
    [SerializeField] float damage;
    [SerializeField] float xpValue;
    Rigidbody2D rb;
    private PlayerStats playerStats;
    private PlayerStats player;
    public SpawnEnemies enemyManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHP = health;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position += direction * speed * Time.deltaTime);
        if(playerStats!=null){ playerStats.TakeDamage(damage); }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.GetComponent<PlayerAttack>();
        if (bullet != null)
        {
            bullet.health -= 1;
            TakeDamage(bullet.damage);
        }

        playerStats = other.GetComponent<PlayerStats>();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<PlayerStats>()!=null)
        {
            playerStats = null;
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
        target.GetComponent<PlayerStats>().GainXP(xpValue);
        health = maxHP;
        enemyManagerScript.RespawnEnemy(this.gameObject, this);
    }
}
