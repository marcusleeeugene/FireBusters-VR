using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    // Index should correspond to fire types
    public enum Type
    {
        Water,
        CarbonDioxide,
        Powder
    }
    public Type type;

    public Type GetExtType()
    {
        return type;
    }
}
