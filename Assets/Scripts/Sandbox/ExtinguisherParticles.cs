using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherParticles : MonoBehaviour
{
    public Extinguisher.Type type;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public Extinguisher.Type GetExtType()
    {
        return type;
    }

    void OnParticleCollision(GameObject other)
    {
        Flammable flammableObj = other.GetComponent<Flammable>();
        if (flammableObj)
        {
            flammableObj.KillFire((int)flammableObj.fireType == (int)type);
        }
    }
}
