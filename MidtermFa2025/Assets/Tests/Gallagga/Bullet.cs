using Gallagga;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public Player player;
    [SerializeField] float life;

    void Start()
    {
        life = 10;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("HIT ENEMY");
            Destroy(other.gameObject);
            bullet.player.AddScore();
            Destroy(this.gameObject);
        }
    }*/
}
