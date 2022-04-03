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
    // private float fadePerSecond = 0.3f;
    public AudioClip fireBurning;
    public AudioClip wrongFireExtinguisher;
    public AudioClip correctFireExtinguisher;
    private AudioSource audioSource;
    private ParticleSystem ps;
    public GameObject correctTick;
    public GameObject wrongCross;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        // Refer to https://youtu.be/eQphjWreQ0U to make sound louder when player near to fire
        if (audioSource)
        {
            //audioSource.Play();
            audioSource.PlayOneShot(fireBurning, PlayerPrefs.GetFloat("SoundVolume"));
        }
        if (wrongCross && correctTick)
        {
            wrongCross = Instantiate(wrongCross);
            wrongCross.SetActive(false);
            correctTick = Instantiate(correctTick);
            correctTick.SetActive(false);
        }
    }

    public void Extinguish(bool shouldExtinguish)
    {
        SetUiPosition();
        if (shouldExtinguish) 
        {
            ps.Stop();

            if (wrongCross && correctTick) 
            {
                wrongCross.SetActive(false);
                correctTick.SetActive(true);
            }
            if (audioSource)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(correctFireExtinguisher, PlayerPrefs.GetFloat("SoundVolume"));
            }
        }
        else 
        {
            if (wrongCross)
            {
                wrongCross.SetActive(true);
            }
            if (audioSource)
            {
                audioSource.PlayOneShot(wrongFireExtinguisher, PlayerPrefs.GetFloat("SoundVolume"));
            }
        }
    }

    public Type GetFireType()
    {
        return type;
    }

    void OnTriggerEnter(Collider collider)
    {
        Flammable flammableObj = collider.GetComponent<Flammable>();
        if (flammableObj)
        {
            flammableObj.LightFire();
        }
    }

    private void SetUiPosition()
    {
        if (wrongCross && correctTick)
        {
            Debug.Log("wrong pos" + wrongCross.transform.position);
            Debug.Log("corr pos" + correctTick.transform.position);
            Debug.Log(gameObject);
            Debug.Log(gameObject.transform.position);
            correctTick.transform.position = gameObject.transform.position + Vector3.up;
            wrongCross.transform.position = correctTick.transform.position;
        }
    }

    // IEnumerator FadingExtinguish()
    // {
    //     var material = GetComponent<Renderer>().material;

    //     while (material.color.a > 0) {
    //         yield return new WaitForSeconds(Time.deltaTime);
    //         var color = material.color;
    //         material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
    //     }

    //     if (audioSource)
    //     {
    //         audioSource.Stop();
    //     }
    //     gameObject.SetActive(false);
    //     // Display category of fire extinguisher
    // }
}
