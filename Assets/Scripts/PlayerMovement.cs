//taken from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2.0f;

    private Vector3 velocity;
    
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(Time.deltaTime * speed * move);
    }
}
