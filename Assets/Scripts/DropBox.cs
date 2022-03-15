using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DropBox : MonoBehaviour
{
    public GameObject toDrop;
    int timesToDrop = 1;

    void OnTriggerEnter(Collider other)
    {
        if (timesToDrop > 0 && toDrop)
        {
            Instantiate(toDrop, transform.position + new Vector3(0, 3, 0), transform.rotation);
            timesToDrop--;
        }
    }
}
