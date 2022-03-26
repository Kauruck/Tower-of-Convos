using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineHelper
{
    public static List<Vector2> generateSattilits(Vector2 point, Vector2 nomral, float distance){
        Vector2 PointA = point + ((Vector2) (Quaternion.Euler(0,0,90) * nomral)).normalized * distance;
        Vector2 PointB = point + ((Vector2) (Quaternion.Euler(0,0,-90) * nomral)).normalized * distance;
        return new List<Vector2> {PointA, PointB};
    }


    //From https://math.stackexchange.com/questions/274712/calculate-on-which-side-of-a-straight-line-is-a-given-point-located
    public static bool onLeftSide(Vector2 a, Vector2 b, Vector2 p){
        float d = (p.x - a.x) * (b.y - a.y) - (p.y - a.y) * (b.x - a.x);
        return d < 0;
    }
}