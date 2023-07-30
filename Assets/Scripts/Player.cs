//Movement parts taken from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
//Rotation parts taken from ChatGPT

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Blaster blaster;
    
    
    private const float Gravity = -9.8f;
    private const float RotationSpeed = 500f;
    private const float VerticalRotationLimit = 80f; // Limit the camera's vertical rotation to prevent flipping
    private const int MouseOneIndex = 0;
    
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float verticalRotation = 0f;

    //------------------------------------------------------------------------------------------------------------------
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        blaster = GetComponentInChildren<Blaster>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    //------------------------------------------------------------------------------------------------------------------

    private void FixedUpdate()
    {
        Movement();
        Rotation();
        Shoot();
    }
    
    //------------------------------------------------------------------------------------------------------------------

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(Time.deltaTime * speed * move);

        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * MathF.Abs(Gravity) * Time.deltaTime);
        }

    }
    
    //------------------------------------------------------------------------------------------------------------------

    private void Rotation()
    {
        float horizontalRotationInput = Input.GetAxis("Mouse X");
        float verticalRotationInput = Input.GetAxis("Mouse Y");

        // Rotate player
        float horizontalRotationAmount = horizontalRotationInput * RotationSpeed * Time.deltaTime;
        verticalRotation -= verticalRotationInput * RotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -VerticalRotationLimit, VerticalRotationLimit);
        transform.Rotate(0f, horizontalRotationAmount, 0f);
        
        //Rotate camera
        Vector3 cameraAngles = transform.GetChild(0).localEulerAngles;
        cameraAngles.x = verticalRotation;
        cameraAngles.z = 0f;
        transform.GetChild(0).localEulerAngles = cameraAngles;
    }
    
    //------------------------------------------------------------------------------------------------------------------

    private void Shoot()
    {
        if (Input.GetMouseButton(MouseOneIndex))
        {
            blaster.Shoot();
        }
    }
}
