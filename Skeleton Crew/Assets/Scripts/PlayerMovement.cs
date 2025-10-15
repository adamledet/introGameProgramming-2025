using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] GameObject playerAttack;
    Rigidbody2D rb;
    bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(moving)
        {
            ApplyMovement(direction * speed * Time.deltaTime);
        }*/
    }

    // Movement when the player uses input
    public void MovePlayer(InputAction.CallbackContext context)
    {
        //moving = true;
        Vector2 dir = context.ReadValue<Vector2>();
        direction = new Vector3(dir.x, dir.y, 0).normalized*speed;
        //Debug.Log($"MOVING: {direction}");
        if(Math.Abs(direction.x) > 0)
        {
            if (direction.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        rb.AddForce(direction);
    }

    //Apply player Movement
    public void ApplyMovement(Vector3 dir)
    {
        rb.AddForce(dir);
        //direction = Vector3.zero;
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            var bullet = Instantiate(playerAttack, transform.position, Quaternion.identity);
            Vector3 dirVector = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized;
            bullet.GetComponent<PlayerAttack>().direction = dirVector;
        }
    }
}
