using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float _fixedDeltaTime;
    public PlayerStats playerStats;
    PlayerController playerControllerClass;




    private void Awake()
    {
        this._fixedDeltaTime = Time.fixedDeltaTime;
    }


    private void Start()
    {
        playerControllerClass = FindObjectOfType<PlayerController>();
        NormalTime();
    }

    private void Update()
    {

    }


    public void DistortTime()
    {
        

        Time.timeScale = 0.5f;

       // Debug.Log("Time is Slowed");

    }

    public void NormalTime()
    {

        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;

        //Debug.Log("Time is Normal");
    }
}
