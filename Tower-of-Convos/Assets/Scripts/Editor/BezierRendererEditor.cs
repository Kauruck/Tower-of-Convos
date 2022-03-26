using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathRenderer))]
public class BezierRendererEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate Texture")){
            ((PathRenderer)target).generateTexture();
        }

    }
}
