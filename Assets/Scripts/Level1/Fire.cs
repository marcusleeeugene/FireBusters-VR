using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isHitCarbonDioxide; // Determines if fire is hit by carbon dioxide
    private bool isHitWater; // Determines if fire is hit by water
    private bool isHitPowder; // Determines if fire is hit by powder
    private float fadePerSecond = 0.3f;
    
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isHitPowder = false;
        isHitCarbonDioxide = false;
        isHitWater = false;
        audioSource = GetComponent<AudioSource>();
        // Refer to https://youtu.be/eQphjWreQ0U to make sound louder when player near to fire
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHitPowder || isHitCarbonDioxide || isHitWater) 
        {
        
            audioSource.Stop();
            StartFade();

            // show green tick and information board what class of fire
            if(isHitCarbonDioxide)
            {
                Debug.Log("Carbon Dioxide fire extinguisher correctly used!");
            } else if(isHitPowder)
            {
                Debug.Log("Powder fire extinguisher correctly used!");
            } else {
                Debug.Log("Water fire extinguisher correctly used!");
            }
        }
    }

    void resetHit()
    {
        isHitCarbonDioxide = false;
        isHitPowder = false;
        isHitWater = false;
    }

    // Fades out fire by fadePerSecond variable then sets active to false once completely faded out. Works only if Standard MAterial Shader's Rendering Mode is set to fade
    private void StartFade() {
        var material = GetComponent<Renderer>().material;
        var color = material.color;

        if(color.a <= 0) {
            resetHit();
            gameObject.SetActive(false);
        }
        material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
    }

    // Detects when Fire is hit by correct fire extinguisher, increments scoreboard then set isHit to true and remove fire from view
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("CarbonDioxide") && (gameObject.CompareTag("FireOilCan") || gameObject.CompareTag("FireFridge"))) 
        {
            isHitCarbonDioxide = true;
        } else if(other.gameObject.CompareTag("Powder") && (gameObject.CompareTag("FireAerosolCan") || gameObject.CompareTag("FireBattery")))
        {
            isHitPowder = true;
        } else if(other.gameObject.CompareTag("Water") && (gameObject.CompareTag("FireChair")))
        {
            isHitWater = true;
        }
    }
}
