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
    private ParticleSystem fumesPs;

    void Start()
    {
        fumesPs = fumes.GetComponent<ParticleSystem>();
        Instantiate(fumes, shootPoint.position, shootPoint.rotation);
    }

    public Type GetExtType()
    {
        return type;
    }

    public void Shoot()
    {
        fumesPs.Stop();
        fumes.transform.position = shootPoint.position;
        fumes.transform.rotation = shootPoint.rotation;
        var main = fumesPs.main;
        main.duration = 1f;
        fumesPs.Play();
    }

    public void Stop()
    {
        fumesPs.Stop();
    }
}
