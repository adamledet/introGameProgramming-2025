using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    [SerializeField] float health;
    [SerializeField] float decel;

    private void Start()
    {
        //health = 10;
        //decel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        health -= Time.deltaTime;
        speed -= decel * Time.deltaTime;
        if(health <=0 || speed<=0)
        {
            DestroySelf();
        }
        transform.position += (direction * speed * Time.deltaTime);
    }

    // Currently used to destroy bullet. Should later be used to turn off and reset position of bullet.
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
