using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnOnHand = true;
    [Tooltip("Required if spawnOnHand is false.")]
    public Transform placeToSpawn;

    public void Spawn()
    {
        if (spawnOnHand) {
            Instantiate(objToSpawn, transform.position + Vector3.up, objToSpawn.transform.rotation);
        } else if (placeToSpawn) {
            Instantiate(objToSpawn, placeToSpawn.position, placeToSpawn.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            Spawn();
        }
    }
}
