using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction;
    private float speed;
    [SerializeField] GameObject playerAttack;
    Rigidbody2D rb;
    bool moving;
    [SerializeField] Renderer background;
    [SerializeField] float bgSlowdown;//hard-set value used to 'slow down' the rate at which the background shifts.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moving = false;
        speed = this.GetComponent<PlayerStats>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)//Check if player is moving using their own movement
        {
            ApplyMovement(direction * speed * Time.deltaTime);
        }
    }

    // Movement when the player uses input
    public void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        if(dir.magnitude > 0) { moving = true; }
        else { moving = false; }
        direction = new Vector3(dir.x, dir.y, 0).normalized * speed;
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
        //rb.AddForce(direction);
    }

    //Apply player Movement
    public void ApplyMovement(Vector3 dir)
    {
        rb.MovePosition(transform.position += dir);
        if (bgSlowdown != 0) { background.material.mainTextureOffset += (new Vector2(dir.x, dir.y)) / bgSlowdown; }
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            var bullet = Instantiate(playerAttack, transform.position, Quaternion.identity);
            Vector2 dirVector = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position);
            bullet.GetComponent<PlayerAttack>().direction = dirVector.normalized;
        }
    }

    public void UpdateSpeed(float newSpd)
    {
        speed = newSpd;
    }
}
