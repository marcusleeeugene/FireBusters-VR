using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabToSpawn : MonoBehaviour
{
    public GameObject objToSpawn;
    public bool spawnOnHand = true;
    [Tooltip("Required if spawnOnHand is false.")]
    public Transform placeToSpawn;

    public void Spawn(Vector3 grabberPos)
    {
        if (spawnOnHand) {
            Instantiate(objToSpawn, grabberPos, Quaternion.identity);
        } else if (placeToSpawn) {
            Instantiate(objToSpawn, placeToSpawn.position, placeToSpawn.rotation);
        }
    }
}
