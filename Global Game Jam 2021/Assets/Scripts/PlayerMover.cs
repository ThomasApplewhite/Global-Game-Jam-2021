using UnityEngine;
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
/*
        // Only process if there is input
        if (lookInputs != Vector2.zero)
        {
            // Rotate body on Y axis of player character to turn left/right
            playerBody.transform.Rotate(new Vector3(0, lookInputs.x * turnSpeed * Time.deltaTime), Space.Self);

            // Build up rotation up/down input over time
            camRotation += lookInputs.y;
            // Clamp up/down rotation within logical bounds
            camRotation = Mathf.Clamp(camRotation, -lookAngleRange, lookAngleRange);
            // Apply rotation to player
            playerHead.localRotation = Quaternion.Euler(-camRotation, 0, 0);

        }
    }*/