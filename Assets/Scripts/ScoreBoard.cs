using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        scoreText.text = "0";
    }

    public void AddScore(int i)
    {
        Global.score += i;
        scoreText.text = Global.score.ToString();
    }
}
