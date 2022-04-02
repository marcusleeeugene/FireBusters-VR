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
        if (fireRef && !fireRef.GetComponent<ParticleSystem>().isPlaying)
        {
            onFire = false;
        }
        if (onFire)
        {
            Debug.Log(fireRef);
            Debug.Log(gameObject);
            fireRef.transform.position = gameObject.transform.position;
        }
    }

    public void LightFire()
    {
        if (!onFire)
        {
            if (!fireRef)
            {
                fireRef = Instantiate(fire);
            }
            else
            {
                fireRef.SetActive(true);
                fireRef.GetComponent<ParticleSystem>().Play();
            }
            onFire = true;
        }
    }

    public void KillFire()
    {
        if (onFire)
        {
            Fire comp = fireRef.GetComponent<Fire>();
            if (comp)
            {
                comp.Extinguish();
            }
            onFire = false;
        }
    }
}
