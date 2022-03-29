using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkParticles : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Flammable flammableObj = other.GetComponent<Flammable>();
        if (flammableObj)
        {
            flammableObj.LightFire();
        }
    }
}
