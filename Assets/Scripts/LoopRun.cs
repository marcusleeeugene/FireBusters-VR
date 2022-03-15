using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRun : MonoBehaviour
{
    private float min=2f;
    private float max=3f;
    public int rotation = 50;

    // Start is called before the first frame update
    void Start()
    {
        min=transform.position.x;
        max=transform.position.x+12;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 4,max-min)+min, transform.position.y, transform.position.z);
        transform.Rotate(new Vector3(0, rotation, 0) * Time.deltaTime);
    }
}
