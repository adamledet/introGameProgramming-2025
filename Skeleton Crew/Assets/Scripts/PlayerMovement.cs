using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    [SerializeField] float speed;
    private Vector3 dir;

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
        if(Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(new Vector3(-speed,0,0));
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(new Vector3(0,-speed,0));
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(new Vector3(0,0,-speed));
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        Console.WriteLine(this.transform.position);
        this.transform.position += direction;
    }
}
