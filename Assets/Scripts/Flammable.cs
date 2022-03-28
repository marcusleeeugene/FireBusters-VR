using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Flammable : MonoBehaviour
{
    public bool onFire = false;
    public Fire.Type fireType;
    public GameObject fire;

    private GameObject fireRef;

    // Start is called before the first frame update
    void Start()
    {
        if (onFire)
        {
            fireRef = Instantiate(fire);
        }
    }

    void Update()
    {
        if (fireRef)
        {
            fireRef.transform.position = gameObject.transform.position;
        }
    }

    public void LightFire()
    {
        if (!fireRef)
        {
            fireRef = Instantiate(fire);
        }
    }
}
