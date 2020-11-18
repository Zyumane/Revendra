using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hex_Matrix 
{
    public const float outRad = 10f;
    public const float innerRad = outRad * 0.866025404f;

    public static Vector3[] corners =
    {
        new Vector3(0f,0f,outRad),
        new Vector3(innerRad,0f,0.5f*outRad),
        new Vector3(innerRad,0f,-0.5f*outRad),
        new Vector3(0f,0f,-outRad),
        new Vector3(-innerRad,0f,-0.5f*outRad),
        new Vector3(-innerRad,0f,0.5f*outRad)
    };
}
