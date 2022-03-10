using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoundaryBackground))]
public class BoundaryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Run")){
            ((BoundaryBackground)this.target).RegenerateTexture();
        }
        base.OnInspectorGUI();
    }
}
