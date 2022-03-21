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

    public static Vector2[] polySort(List<Vector2> pointsList) {
    IEnumerable<Vector2> points = pointsList;
    // Get "centre of mass"
    Vector2 center = points.Aggregate((sum, current) => sum + current);
    center = center / pointsList.Count;

    PointHolder[] newPoints = new PointHolder[pointsList.Count];
    // Sort by polar angle and distance, centered at this centre of mass.
    for(int i = 0; i < pointsList.Count; i++){
        Vector2 point = pointsList[i];
        newPoints[i] = new PointHolder(point, squaredPolar(point, center));
    } 
    
    return newPoints.OrderBy(x => x.sort, new PointComparer()).Select(x => x.point).ToArray();
    }


    private static Vector2 squaredPolar(Vector2 point, Vector2 centre) {
    return new Vector2(
        Mathf.Atan2(point.y-centre.y, point.x -centre.x),
        Mathf.Pow(point.x-centre.x, 2) + Mathf.Pow(point.y-centre.y, 2)); // Square of distance
}
}

struct PointHolder {
    public Vector2 point;
    public Vector2 sort;

    public PointHolder(Vector2 pPoint, Vector2 pSort){
        point = pPoint;
        sort = pSort;
    }
}

class PointComparer : IComparer<Vector2>{

    public int Compare(Vector2 a, Vector2 b){
        return (int) (a.x - b.x == 0 ? a.y - b.y : a.x - b.x);
    }
}