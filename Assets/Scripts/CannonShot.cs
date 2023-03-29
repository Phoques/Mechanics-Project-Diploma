using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform spawnpoint;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, spawnpoint.position, projectile.transform.rotation);
            clone.velocity = spawnpoint.TransformDirection(Vector3.forward*20);
        }
    }


}
