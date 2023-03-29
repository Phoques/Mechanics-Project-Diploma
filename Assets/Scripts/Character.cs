using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterController charC;

    public float speed = 5f;

    private void Start()
    {
        charC= GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        charC.Move(move * Time.deltaTime * speed);
    }


}
