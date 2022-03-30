using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSandbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hand")
            SceneManager.LoadScene("Start Point");
    }
}
