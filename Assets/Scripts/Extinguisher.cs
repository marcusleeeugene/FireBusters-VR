using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    // Index should correspond to fire types
    public enum Type
    {
        Water,
        CarbonDioxide,
        Powder
    }
    public Type type;
    public Transform shootPoint;
    public GameObject fumes;

    void Start()
    {
        Instantiate(fumes, shootPoint.position, shootPoint.rotation);
        fumes.gameObject.SetActive(false);
    }

    public Type GetExtType()
    {
        return type;
    }

    public void Shoot()
    { 
        fumes.transform.position = shootPoint.position;
        fumes.transform.rotation = shootPoint.rotation;
        // var main = fumesPs.main;
        // main.duration = 1f;
        fumes.gameObject.SetActive(true);
    }

    public void Stop()
    {
        fumes.gameObject.SetActive(false);
    }
}
