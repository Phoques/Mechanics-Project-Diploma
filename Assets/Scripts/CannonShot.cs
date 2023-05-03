using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform spawnpoint;
    bool _canShoot;

    private void Start()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if(_canShoot)
        {
            StartCoroutine(ShootCannon());
        }
    }

    IEnumerator ShootCannon()
    {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(projectile, spawnpoint.position, Quaternion.identity );   //projectile.transform.rotation
        clone.velocity = spawnpoint.TransformDirection(Vector3.forward * 20);
        _canShoot = false;
        yield return new WaitForSecondsRealtime(1.4f);
        _canShoot = true;
    }

}
