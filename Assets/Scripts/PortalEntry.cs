using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("GameController"))
        {
            int levelNumber =  transform.GetSiblingIndex() + 1;     // 1 <= levelNumber <= 4
            Debug.Log(string.Format("Going to level {0} now!!!", levelNumber));
        }
    }
}
