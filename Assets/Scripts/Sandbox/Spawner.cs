using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnOnHand = true;
    [Tooltip("Required if spawnOnHand is false.")]
    public Transform placeToSpawn;

    public AudioSource spawnAudio;

    public virtual void Spawn()
    {
        if (spawnOnHand) {
            Instantiate(objToSpawn, transform.position + Vector3.up, objToSpawn.transform.rotation);
            if (spawnAudio) {
                spawnAudio.Play();
            }
        } else if (placeToSpawn) {
            Instantiate(objToSpawn, placeToSpawn.position, placeToSpawn.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            Spawn();
        }
    }
}
