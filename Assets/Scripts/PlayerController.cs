using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool _distortingTime;

    public Text timeReport;


    Vector3 velocity;

    public PlayerStats playerStats;

    private TimeManager timeManagerClass;

    private void Start()
    {
        playerStats.timeMechanic = playerStats.timeMechanicMax;
        playerStats.timeMechanic = Mathf.Clamp(playerStats.timeMechanic, -1, playerStats.timeMechanicMax);

        timeManagerClass = FindObjectOfType<TimeManager>();

        timeReport.text = "Time Slow Ready";

    }

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

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        charC.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(1) && !_distortingTime)
        {
            StartCoroutine(SlowTime());
        }
 

    }
       
   
    IEnumerator SlowTime()
    {
        _distortingTime = true;
        timeManagerClass.DistortTime();
        Debug.Log("Slowing Time");
        timeReport.text = "Slowing time!";
        yield return new WaitForSecondsRealtime(5);
        timeManagerClass.NormalTime();
        Debug.Log("Normal Time");
        timeReport.text = "Recharging";
        yield return new WaitForSecondsRealtime(5);
        _distortingTime = false;
        Debug.Log("Can Shift Time Again");
        timeReport.text = "Time Slow Ready";

    }
}
