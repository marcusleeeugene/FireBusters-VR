using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnSwitch : Spawner
{
    public int spawnLimit = 1;
    
    private int spawnedNum = 0;
    private List<GameObject> objs = new List<GameObject>();

    public override void Spawn()
    {
        List<GameObject> toRemove = new List<GameObject>();
        foreach (GameObject obj in objs) 
        {
            if (obj.activeSelf == false)
            {
                toRemove.Add(obj);
            }
        }
        objs = objs.Except(toRemove).ToList();
        spawnedNum = objs.Count;

        if (spawnedNum < spawnLimit)
        {
            GameObject instance = null;
            if (spawnOnHand) {
                instance = Instantiate(objToSpawn, transform.position + Vector3.up, objToSpawn.transform.rotation);
            } else if (placeToSpawn) {
                instance = Instantiate(objToSpawn, placeToSpawn.position, placeToSpawn.rotation);
            }
            if (instance)
            {
                objs.Add(instance);
            }
            spawnedNum++;
        }
    }
}
