using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTutorial : MonoBehaviour
{
    PlayerController playerControllerClass;
    public bool tutorialDone;


    private void Start()
    {
        tutorialDone = false;
        playerControllerClass = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    if (other.tag == "Player")
        {
            tutorialDone = true;
            playerControllerClass.tutorial.text = "There are deadly bullets ahead, be careful!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerControllerClass.tutorial.text = "";
        }
    }
}
