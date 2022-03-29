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
    private float fadePerSecond = 0.3f;

    private AudioSource audioSource;
    private bool isExtinguishing = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Refer to https://youtu.be/eQphjWreQ0U to make sound louder when player near to fire
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    public void Extinguish()
    {
        if (!isExtinguishing)
        {
            isExtinguishing = true;
            gameObject.SetActive(false);
            // StartCoroutine(FadingExtinguish());
            isExtinguishing = false;
        }
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

    IEnumerator FadingExtinguish()
    {
        var material = GetComponent<Renderer>().material;

        while (material.color.a > 0) {
            yield return new WaitForSeconds(Time.deltaTime);
            var color = material.color;
            material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        }

        if (audioSource)
        {
            audioSource.Stop();
        }
        gameObject.SetActive(false);
        // Display category of fire extinguisher
    }
}
