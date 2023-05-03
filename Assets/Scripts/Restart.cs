using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestartLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);

    }
}
