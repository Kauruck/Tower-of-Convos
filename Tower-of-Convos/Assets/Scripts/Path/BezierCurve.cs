using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BezierCurve
{
    public Vector2 pointA;
    public Vector2 pointB;
    public Vector2 controllA;
    public Vector2 controllB;
    public float length;
    public float txValue;
}
