using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            StopAllCoroutines();
            SceneManager.LoadScene(1);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }

 
}
