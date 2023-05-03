using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    BoxTutorial BT;
    

    PlayerController playerControllerClass;


    private void Start()
    {
        playerControllerClass = FindObjectOfType<PlayerController>();
        BT = FindObjectOfType<BoxTutorial>();
    }


    void Update()
    {//position of this game object need to move towards the target (set in inspector) of the list of waypoints, at movespeed, normalised.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //If this objects position is equal to the assigned target
        if (transform.position == waypoints[target].position)
        {
            StartCoroutine(MovingPlatform());

        }

    }


    IEnumerator MovingPlatform()
    {
        // If the assigned target is equal to the end of the list, the target is waypoint 0 / target 0.
        if (target == waypoints.Count - 1)
        {
            yield return new WaitForSeconds(1f);
            target = 0;

        }
        else
        {
            //Else move towards target 1
            yield return new WaitForSeconds(1f);
            target = 1;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && BT.tutorialDone == false)
        {
            playerControllerClass.tutorial.text = "These platforms are slippery! \n Right click to dilute time for a short period to stay ontop.";
        }
    }




    //The below two assign the character as a child to the platform, which means they follow the platforms transform instead of staying still.
    //This DOESNT WORK, need to revise.
    /* private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player")
         {
             other.transform.SetParent(transform);
         }
     }

     private void OnTriggerExit(Collider other)
     {
         if (other.tag == "Player")
         {
             other.transform.SetParent(null);

         }
     }*/

}
