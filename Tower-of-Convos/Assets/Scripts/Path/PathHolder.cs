using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathHolder : MonoBehaviour
{

    public BezierCurve[] curves = new BezierCurve[1];
    public Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnDrawGizmosSelected(){
        if(curves.Length > 0){
            Gizmos.color = Color.red;
            int res = 20;
            float stepSize = 1f/res;
            Vector2 oldPos = BezierHelper.calcPosition(curves[0], 0);
            foreach(BezierCurve current in curves) {
                for(int i = 0; i <= res; i++){
                    Vector2 newPos = BezierHelper.calcPosition(current, stepSize * i);
                    Gizmos.DrawLine(oldPos, newPos);
                    oldPos = newPos;
                }

                Gizmos.DrawWireSphere(current.pointA, 0.5f);
                Gizmos.DrawWireSphere(current.pointB, 0.5f);
                Gizmos.DrawWireSphere(current.controllA, 0.5f);
                Gizmos.DrawWireSphere(current.controllB, 0.5f);
            }
        }
    }
}
