﻿using UnityEngine;
using UnityEngine.InputSystem; // NEW! You must use UnityEngine.InputSystem!

//now including some changes for look sensitivity lol

public class BasicPlayerController : MonoBehaviour
{
    [Header("Inputs")]
    public Vector2 moveInputs; // X for move left/right, Y for move forward/back
    public Vector2 lookInputs; // X for rotate left/right, Y for look up/down

    [Header("Moving")]
    public Rigidbody playerBody; // to walk, move body, not this
    public float movementSpeed = 250; // multiplier for movement
    public float turnSpeed = 100; // multiplier for turning

    [Header("Looking")]
    public Transform playerHead; // to look, rotate head or body (axis depending), not this
    public float lookAngleRange = 60; // 60' up, 60' down
    private float camRotation = 0; // current camera up/down rotation value

    [Header("CUSTOM")]
    [Range(1f, 10f)]
    public float lookSensitiviy = 1f;
    public float forceOfGravity = 100f;

    #region Receive Input Values
    // Call these functions from the PlayerInput component as set up by this guide:
    // https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html#getting-input-indirectly-through-an-input-action
    // This is designed for you to use "Action Responses" when 
    // Player Input Behaviour is set to "Invoke Unity Events", 
    // and then you can point those events to these functions.

    // Because the CallbackContext object is generic, you must call ReadValue<T>
    // and specify the type that you're expecting. Read more on C# generics here:
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/

    public void UpdateMoveInputs(InputAction.CallbackContext context)
    {
        moveInputs = context.ReadValue<Vector2>();
    }

    public void UpdateLookInputs(InputAction.CallbackContext context)
    {
        lookInputs = context.ReadValue<Vector2>();
    }
    #endregion

    // Keep input in Update when possible for smoother UX
    private void Update()
    {
        // Only process if there is input
        if (lookInputs != Vector2.zero)
        {
            // Rotate body on Y axis of player character to turn left/right
            playerBody.transform.Rotate(new Vector3(0, (lookInputs.x/lookSensitiviy) * turnSpeed * Time.deltaTime), Space.Self);

            // Build up rotation up/down input over time
            camRotation += lookInputs.y/lookSensitiviy;
            // Clamp up/down rotation within logical bounds
            camRotation = Mathf.Clamp(camRotation, -lookAngleRange, lookAngleRange);
            // Apply rotation to player
            playerHead.localRotation = Quaternion.Euler(-camRotation, 0, 0);

        }
    }

    // Keep physics-based things in FixedUpdate to reduce performance impact
    private void FixedUpdate()
    {
        // Only process if there is input
        if (moveInputs != Vector2.zero)
        {
            // Move around in XZ space
            playerBody.AddRelativeForce(new Vector3(moveInputs.x * movementSpeed * Time.deltaTime, -20f * Time.deltaTime, moveInputs.y * movementSpeed * Time.deltaTime), ForceMode.Impulse);
        }

        //apply graviy
        playerBody.AddRelativeForce(new Vector3(0, -forceOfGravity, 0));
    }
}
