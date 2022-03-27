using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathHolder))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate Collider")){
            ((PathHolder)target).generateCollider();
        }

    }



    public void OnSceneGUI(){
        PathHolder holder = (PathHolder) target;
        PathRenderer render = holder.GetComponent<PathRenderer>();
        Handles.color = Color.red;
        #region BezierHandelsLine
        foreach(BezierCurve current in holder.curves){
            Handles.DrawLine(current.pointA, current.controllA);
            Handles.DrawLine(current.pointB, current.controllB);
        }
        #endregion
        #region BezierCurves
        int res = 20;
        float stepSize = 1f/res;
        Vector2 oldPos = BezierHelper.calcPosition(holder.curves[0], 0);
        foreach(BezierCurve current in holder.curves) {
            for(int i = 0; i <= res; i++){
                Vector2 newPos = BezierHelper.calcPosition(current, stepSize * i);
                Handles.DrawLine(oldPos, newPos);
                oldPos = newPos;
            }
        }
        #endregion
        #region Handels
        for(int i = 0; i < holder.curves.Length * 4; i++){
            EditorGUI.BeginChangeCheck();
            Vector3 currentPos = Handles.PositionHandle(holder[i], Quaternion.identity);
            if(EditorGUI.EndChangeCheck()){
                Undo.RecordObject(holder, "Moved curve controll points");
                holder[i] = currentPos;
                holder.generateCollider();
                if(render is {}){
                    render.generateTexture();
                }
            }
        }
        #endregion
    }
    
}
