using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Coral))]
public class CoralEditor : PropertyDrawer{


    private int offset = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        offset = 0;
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        drawProperty("centerPosition", "Center", position, property);
        drawProperty("radius", "Radius", position, property);
        /* SerializedProperty it = property.Copy ();
 while (it.Next (true)) { // or NextVisible, also, the bool argument specifies whether to enter on children or not
     Debug.Log (it.name);
 }*/

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    private void drawProperty(string propertyName, string label, Rect position, SerializedProperty property)
    {
        Rect labelRect = new Rect(position.x , position.y + offset, position.width/2 - 10, 20);
        Rect varRect = new Rect(position.x + position.width/2, position.y + offset, position.width/2, 20);

        offset += 22;

        EditorGUI.LabelField(labelRect, label);
        EditorGUI.PropertyField(varRect, property.FindPropertyRelative(propertyName), GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 22*2;
    }}