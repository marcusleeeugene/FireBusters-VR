using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Requires collider to be a trigger and will register a trigger collision when an object with a non-trigger collider and flammable script happens.
One of the colliding objects must have a Rigidbody.
*/
[RequireComponent(typeof(BoxCollider))]
public class Fire : MonoBehaviour
{
    // Index should correspond to extinguisher types
    public enum Type
    {
        Solid,
        Liquid,
        Gas,
    }
    public Type type;

    void Start()
    {

    }

    public void Extinguish()
    {
        gameObject.SetActive(false);
    }

    public Type GetFireType()
    {
        return type;
    }

    void OnTriggerEnter(Collider collider)
    {
        Extinguisher extinguisher = collider.GetComponent<Extinguisher>();
        if (extinguisher)
        {
            Extinguisher.Type extType = extinguisher.GetExtType();
            if ((int)type == (int)extType)
            {
                Extinguish();
            }
        }
        Flammable flammableObj = collider.GetComponent<Flammable>();
        if (flammableObj)
        {
            flammableObj.LightFire();
        }
    }
}
