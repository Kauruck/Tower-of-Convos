using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    public Vector2 pointA;
    public Vector2 pointB;
    // Start is called before the first frame update
    void OnDrawGizmosSelected(){
        List<Vector2> points = LineHelper.generateSattilits(pointA, pointB - pointA, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(points[0], 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.DrawSphere(pointB, 0.1f);
        Gizmos.DrawLine(pointA, pointB);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(points[1], 0.1f);
    }
}
