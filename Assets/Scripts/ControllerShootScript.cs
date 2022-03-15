using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerShootScript : MonoBehaviour
{
    public float thrust = 10;
    public AudioSource shootAudio;

    public void Shoot(GameObject toShoot)
    {
        if (toShoot)
        {
            shootAudio.Play();
            Rigidbody rb = toShoot.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(transform.forward * thrust);
            }
        }
    }
}
