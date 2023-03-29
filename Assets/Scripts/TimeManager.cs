using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float _fixedDeltaTime;
    public PlayerStats playerStats;

    private void Awake()
    {
        this._fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && playerStats.timeMechanicCurrent > 0)
        {
            playerStats.timeMechanicCurrent -= playerStats.timeMechanicDrain * Time.deltaTime;
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.5f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
            Time.fixedDeltaTime = this._fixedDeltaTime * Time.timeScale;
        }
    }


}
