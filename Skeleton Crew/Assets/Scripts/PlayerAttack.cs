using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerAttack : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    [SerializeField] public float health;
    [SerializeField] public float damage;
    [SerializeField] float decel;
    private int decayCounter;


    private void Start()
    {
        decayCounter = 0;
        //health = 10;
        //decel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        health -= Time.deltaTime;
        decayCounter++;
        if(health <=0 || speed<=0)
        {
            DestroySelf();
        }
    }

    private void FixedUpdate()
    {
        speed -= decel * Time.deltaTime * decayCounter;
        decayCounter++;
        transform.position += (direction * speed * Time.deltaTime);
    }

    // Currently used to destroy bullet. Should later be used to turn off and reset position of bullet.
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
