using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isHit; // Determines if fire is hit by water
    private float fadePerSecond = 0.3f;
    private ScoreBoard scoreBoard;
    
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreBoard>();
        audioSource = GetComponent<AudioSource>();
        // Refer to https://youtu.be/eQphjWreQ0U to make sound louder when player near to fire
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit) {
            audioSource.Stop();
            StartFade();
        }
    }

    // Fades out fire by fadePerSecond variable then sets active to false once completely faded out. Works only if Standard MAterial Shader's Rendering Mode is set to fade
    private void StartFade() {
        var material = GetComponent<Renderer>().material;
        var color = material.color;

        if(color.a <= 0) {
            isHit = false;
            gameObject.SetActive(false);
        }
        material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
    }

    // Detects when Fire is hit by Water, increments scoreboard then set isHit to true and remove water ammo from view
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Water"))
        {
            isHit = true;
            other.gameObject.SetActive(false);
            scoreBoard.AddScore(1);
        }
    }
}
