using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathHolder : MonoBehaviour
{

    public BezierCurve[] curves = new BezierCurve[1];
    public Texture2D texture;

    public Vector3 test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public Vector2 this[int index]{
        set => setPostionFromIndex(index, value);
        get => getPostionFromIndex(index);
    }

    public int Length {
        get => this.curves.Length * 4;
    }

    private void setPostionFromIndex(int index, Vector3 value){
        try{
            int curveIndex = Mathf.FloorToInt(index/4f);
            BezierCurve curve = this.curves[curveIndex];
            switch (index % 4){
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
            if(index % 4 == 0 && index > 1){
                setPostionFromIndex(index - 1, value);
            }
            else if(index % 4 == 3 && index < this.Length - 1){
                setPostionFromIndex(index + 1, value);
            }
        }
        catch(Exception e){
            Debug.Log(e.ToString());
        }
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
