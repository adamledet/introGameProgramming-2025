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

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement(direction * speed * Time.deltaTime);
    }

    // Movement when the player uses input
    public void MovePlayer(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        direction = new Vector3(dir.x, dir.y, 0).normalized;
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
    }

    //Apply player Movement
    public void ApplyMovement(Vector3 dir)
    {
        transform.position += dir;
        //direction = Vector3.zero;
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        var bullet = Instantiate(playerAttack, transform.position, Quaternion.identity);
        Vector3 dirVector = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized;
        bullet.GetComponent<PlayerAttack>().direction = dirVector;
    }
}
