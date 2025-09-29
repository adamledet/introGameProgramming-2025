using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class PlayerAttack : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    [SerializeField] float health;
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
        transform.position += (direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        speed -= decel * Time.deltaTime * decayCounter;
        decayCounter++;
    }

    // Currently used to destroy bullet. Should later be used to turn off and reset position of bullet.
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
