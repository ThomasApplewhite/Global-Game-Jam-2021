﻿using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMover : MonoBehaviour
{
    public float speed;
    public float gravity;

    Vector3 movementDirection;
    CharacterController controller;
    Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = movementDirection * speed;
        //movement.y = gravity;

        controller.Move(movement);
    }

    public void OnMove(InputValue input)
    {
        Vector2 moveDirect = input.Get<Vector2>();

        movementDirection = new Vector3(
            moveDirect.x,
            0,
            moveDirect.y
        );
    }
}
