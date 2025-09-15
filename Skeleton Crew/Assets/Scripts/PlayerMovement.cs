using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    [SerializeField] float speed;
    private Vector3 direction;
    private bool moving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(new Vector3(0, -1, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(new Vector3(0, 0, -1));
        }

        if (moving)
        {
            transform.position += (direction) * speed * Time.deltaTime;
        }
    }

    public void MovePlayer(Vector3 dir)
    {
        direction += dir;
    }
}
