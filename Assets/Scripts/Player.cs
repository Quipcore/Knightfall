//taken from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Blaster blaster;
    public float speed = 2.0f;
    private const int MouseOneIndex = 0;

    private Vector3 velocity;
    
    public float rotationSpeed = 500f;
    public float verticalRotationLimit = 80f; // Limit the camera's vertical rotation to prevent flipping

    private float verticalRotation = 0f;
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        blaster = GetComponentInChildren<Blaster>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        Movement();
        Rotation();
        Shoot();
        
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(Time.deltaTime * speed * move);
    }

    private void Rotation()
    {
        // Get the horizontal mouse input for rotation
        float horizontalRotationInput = Input.GetAxis("Mouse X");
        // Get the vertical mouse input for camera rotation
        float verticalRotationInput = Input.GetAxis("Mouse Y");

        // Calculate the rotation angles
        float horizontalRotationAmount = horizontalRotationInput * rotationSpeed * Time.deltaTime;
        verticalRotation -= verticalRotationInput * rotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        // Rotate the player and camera around the Y-axis
        transform.Rotate(0f, horizontalRotationAmount, 0f);

        // Rotate the camera around the X-axis
        // Get the current camera rotation angles
        Vector3 cameraAngles = transform.GetChild(0).localEulerAngles;

        // Apply the vertical rotation to the camera
        cameraAngles.x = verticalRotation;

        // Zero out the camera's rotation around the Z-axis to prevent weird tilting
        cameraAngles.z = 0f;

        // Apply the modified rotation angles to the camera
        transform.GetChild(0).localEulerAngles = cameraAngles;
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(MouseOneIndex))
        {
            Debug.Log("m1Pressed");
            blaster.Shoot();
        }
    }
}
