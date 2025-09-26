using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;

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
    }

    //Apply player Movement
    public void ApplyMovement(Vector3 dir)
    {
        transform.position += dir;
        //direction = Vector3.zero;
    }

    public void PlayerAttack(InputAction.CallbackContext context)
    {
        Debug.Log($"Player Attack: {context}");
    }
}
