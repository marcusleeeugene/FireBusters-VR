using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilParticles : MonoBehaviour
{
    public GameObject fire;
    // private ParticleSystem ps;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     ps = GetComponent<ParticleSystem>();
    // }

    void OnParticleCollision(GameObject other)
    {
        Fire otherFire = other.GetComponent<Fire>();
        if (otherFire)
        {
            Instantiate(fire, transform.position, Quaternion.identity);
        }
    }
}
