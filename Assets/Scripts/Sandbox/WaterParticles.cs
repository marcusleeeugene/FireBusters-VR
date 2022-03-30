using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticles : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        Flammable flammableObj = other.GetComponent<Flammable>();
        if (flammableObj && flammableObj.fireType==Fire.Type.Solid)
        {
            flammableObj.KillFire();
        }
    }
}
