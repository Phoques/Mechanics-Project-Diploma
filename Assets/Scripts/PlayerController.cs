using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController charC;
    public float speed = 12;
    public float gravity = -9f;
    public float jump = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool _isGrounded;

    Vector3 velocity;


    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && velocity.y is < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charC.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        charC.Move(velocity * Time.deltaTime);
    }

}
