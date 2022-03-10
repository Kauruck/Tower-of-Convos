using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierHelper
{
    public const int lengthRes = 100;
    public static Vector2 calcPosition(BezierCurve curve, float t){
        t = Mathf.Clamp01(t);

        float x = ((1 - t) * (1 - t) * (1 - t)) * curve.pointA.x
           + 3 * ((1 - t) * (1 - t)) * t * curve.controllA.x
           + 3 * (1 - t) * (t * t) * curve.controllB.x
           + (t * t * t) * curve.pointB.x;

        float y = ((1 - t) * (1 - t) * (1 - t)) * curve.pointA.y
           + 3 * ((1 - t) * (1 - t)) * t * curve.controllA.y
           + 3 * (1 - t) * (t * t) * curve.controllB.y
           + (t * t * t) * curve.pointB.y;

        return new Vector2(x,y);
    }

    public static float lengthOfCurve(BezierCurve curve){
        float[] lengthArray = new float[lengthRes + 1];
        lengthArray[0] = 0;
        Vector2 prevPos=calcPosition(curve, 0);
        float  cLength = 0;
        float stepSize = 1f/lengthRes;
        for(int i = 1; i <= lengthRes; i++){
            Vector2 point = calcPosition(curve, stepSize * i);
            float dx = prevPos.x - point.x;
            float dy = prevPos.y - point.y;
            cLength += Mathf.Sqrt(dx * dx + dy * dy);
            lengthArray[i] = cLength;
            prevPos = point;
        }

        return cLength;
    }

    public float lengthOfCurve(BezierCurve curve, out float[] parts){
        float[] lengthArray = new float[lengthRes];
        lengthArray[0] = 0;
        Vector2 prevPos=calcPosition(curve, 0);
        float  cLength = 0;
        float stepSize = 1/lengthRes;
        for(int i = 1; i <= lengthRes; i++){
            Vector2 point = calcPosition(curve, stepSize * i);
            float dx = prevPos.x - point.x;
            float dy = prevPos.y - point.y;
            cLength += Mathf.Sqrt(dx * dx + dy * dy);
            lengthArray[i] = cLength;
            prevPos = point;
        }

        parts = lengthArray;
        return cLength;
    }

    public static float txValue(BezierCurve curve){
        return 1f/curve.length;
    }
}
