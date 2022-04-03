using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public bool isExtinguisher(GameObject obj)
    {
        return obj.GetComponent<Extinguisher>() != null;
    }

    public void ShootExtinguisher(GameObject obj)
    {
        Extinguisher ext = obj.GetComponent<Extinguisher>();
        if (ext)
        {
            ext.Shoot();
        }
    }

    public void Stop(GameObject obj)
    {
        Extinguisher ext = obj.GetComponent<Extinguisher>();
        if (ext)
        {
            ext.Stop();
        }
    }
}
