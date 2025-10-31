using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerAttack : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    [SerializeField] public float health;
    [SerializeField] public float damage;
    Rigidbody2D rb;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed);
        //Debug.Log(direction);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //Debug.Log(rb.linearVelocity.magnitude);
        rb.linearVelocity *= 0.9f;
        health -= Time.deltaTime;
        if(rb.linearVelocity.magnitude<1)
        {
            if (health < 0)
            {
                DestroySelf();
            }
        }
        /*transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        speed *= 0.9f;
        if (speed < 1)
        {
            health -= Time.deltaTime;
            if (health < 0)
            {
                DestroySelf();
            }
        }*/
    }

    // Currently used to destroy bullet. Should later be used to turn off and reset position of bullet.
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
