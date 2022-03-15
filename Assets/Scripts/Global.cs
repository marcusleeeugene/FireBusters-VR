using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static GameObject laserInFocus;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        laserInFocus = null;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
