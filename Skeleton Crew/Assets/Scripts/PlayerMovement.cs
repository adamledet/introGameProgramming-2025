using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    public float speed;
    public InputAction moveUp;
    public InputAction moveDown;
    public InputAction moveLeft;
    public InputAction moveRight;

    public InputAction MoveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(new Vector3(0,speed,0));
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        Console.WriteLine(this.transform.position);
        this.transform.position += direction;
    }
}
