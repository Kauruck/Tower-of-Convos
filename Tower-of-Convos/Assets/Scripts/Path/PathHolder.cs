using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(EdgeCollider2D))]
public class PathHolder : MonoBehaviour
{

    public BezierCurve[] curves = new BezierCurve[1];
    public Texture2D texture;
    public float ColliderWidth = 0.2f;

    private EdgeCollider2D PathCollider;

    public float pointsPerCollider = 100;

    void Start(){
        this.PathCollider = this.GetComponent<EdgeCollider2D>();
    }

    public Vector2 this[int index]{
        set => setPostionFromIndex(index, value);
        get => getPostionFromIndex(index);
    }

    public Vector2 this[float t]{
        get => getPositionFromT(t, 0);
    }

    public int Length {
        get => this.curves.Length * 4;
    }

    public int maxT {
        get => this.curves.Length;
    }

    public BezierCurve getCurveForT(float t){
        return this.curves[Mathf.FloorToInt(t)];
    }

    public void generateCollider(){
        float stepSize = 1/pointsPerCollider;
        List<Vector2> colliderPoints = new List<Vector2>();
        List<Vector2> colliderPointsBack = new List<Vector2>();
        foreach(BezierCurve curve in curves){
            for(float t = 0; t <= 1; t += stepSize){
                Vector2 currentPoint = BezierHelper.calcPosition(curve, t);
                Vector2 normal =  BezierHelper.getNormalForCurve(curve, t, stepSize);
                Vector2 normalPoint = currentPoint + normal;
                List<Vector2> points = LineHelper.generateSattilits(currentPoint, normal, ColliderWidth);
                //So that it does not cross the line when it turns
                if(LineHelper.onLeftSide(currentPoint, normalPoint, points[0])){
                    colliderPoints.Add(points[0]);
                    colliderPointsBack.Add(points[1]);
                }
                else {
                    colliderPoints.Add(points[1]);
                    colliderPointsBack.Add(points[0]);
                }
            }
        }
        //So that it goes back
        colliderPointsBack.Reverse();
        colliderPoints.AddRange(colliderPointsBack);
        //So that the collider is closed
        colliderPoints.Add(colliderPoints[0]);
        this.PathCollider.points = colliderPoints.ToArray();
    }

    private Vector2 getPositionFromT(float t, int curveIndex){
        if(curveIndex >= this.curves.Length)
            return BezierHelper.calcPosition(this.curves[this.curves.Length - 1], 1);
        if(t <= 1)
            return BezierHelper.calcPosition(this.curves[curveIndex], t);
        return getPositionFromT(t - 1, curveIndex + 1);
    }

    private void setPostionFromIndex(int index, Vector3 value){
        try{
            int curveIndex = Mathf.FloorToInt(index/4f);
            BezierCurve curve = this.curves[curveIndex];
            switch (index % 4){
                case 0:
                    curve.pointA = value;
                    updatePoint(curveIndex - 1, 3, value);
                    break;
                case 3:
                    curve.pointB = value;
                    updatePoint(curveIndex + 1,0, value);
                    break;
                case 1:
                    curve.controllA = value;
                    Vector2 mirrordValueA = mirrorPoint(value, curve.pointA);
                    updatePoint(curveIndex - 1, 2, mirrordValueA);
                    break;
                case 2:
                    curve.controllB = value;
                    Vector2 mirrordValueB = mirrorPoint(value, curve.pointB);
                    updatePoint(curveIndex + 1, 1, mirrordValueB);
                    break;
            }
            this.curves[curveIndex] = curve;
        }
        catch(Exception e){
            Debug.Log(e.ToString());
        }
    }

    public Vector2 getPointOnCurves(float distance){
        if(curves.Length == 0)
            throw new NullReferenceException("There must be at least on curve!");
        BezierCurve curve = curves[0];
        if(distance <= curve.length){
            float t = curve.txValue * distance;
            return BezierHelper.calcPosition(curve, t);
        }
        return getPointOnCurves(distance - curve.length, 1);
    }

    public float PathLength {
        get => pathLength();
    }

    private float pathLength(){
        float length = 0;
        foreach(BezierCurve curve in curves){
            length += curve.length;
        }
        return length;
    }

    private Vector2 getPointOnCurves(float distance, int curveIndex){
        if(curveIndex >= curves.Length)
            return BezierHelper.calcPosition(curves[curves.Length - 1], 1);
        BezierCurve curve = curves[curveIndex];
        if(distance <= curve.length){
            float t = curve.txValue * distance;
            return BezierHelper.calcPosition(curve, t);
        }
        return getPointOnCurves(distance - curve.length, curveIndex + 1);
    }

    private Vector2 mirrorPoint(Vector2 p, Vector2 x){
        Vector2 a = p - x;
        return x + -1 * a;
    }

    private void updatePoint(int curveIndex, int pointIndex, Vector2 value){
        if(curveIndex < 0 || curveIndex >= curves.Length)
            return;
        BezierCurve curve = this.curves[curveIndex];
        switch(pointIndex){
            case 0:
                curve.pointA = value;
                break;
            case 3:
                curve.pointB = value;
                break;
            case 1:
                curve.controllA = value;
                break;
            case 2:
                curve.controllB = value;
                break;
        }
        this.curves[curveIndex] = curve;
    }

    private Vector2 getPostionFromIndex(int index){
        int curveIndex = Mathf.FloorToInt(index/4f);
        BezierCurve curve = this.curves[curveIndex];
        switch (index % 4){
            case 0:
                return curve.pointA;
            case 3:
                return curve.pointB;
            case 1:
                return curve.controllA;
            case 2:
                return curve.controllB;
            
            //Never happens
            default:
                return curve.pointA;
        }
    }

}
