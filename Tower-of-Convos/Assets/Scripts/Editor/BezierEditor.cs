using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BezierCurve))]
public class BezierEditor : PropertyDrawer{


    private int offset = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        offset = 0;
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        drawProperty("pointA", "A", position, property);
        drawProperty("pointB", "B", position, property);
        drawProperty("controllA", "C", position, property);
        drawProperty("controllB", "D", position, property);
        drawFlaotLable("length", "Length", position, property);
        drawFlaotLable("txValue", "T/X", position, property);

        BezierCurve tmpCurve = new BezierCurve();
        tmpCurve.pointA = property.FindPropertyRelative("pointA").vector2Value;
        tmpCurve.pointB = property.FindPropertyRelative("pointB").vector2Value;
        tmpCurve.controllA = property.FindPropertyRelative("controllA").vector2Value;
        tmpCurve.controllB = property.FindPropertyRelative("controllB").vector2Value;
        tmpCurve.length = BezierHelper.lengthOfCurve(tmpCurve);
        property.FindPropertyRelative("length").floatValue = tmpCurve.length;
        property.FindPropertyRelative("txValue").floatValue = BezierHelper.txValue(tmpCurve);
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

    private void drawFlaotLable(string propertyName, string label, Rect position, SerializedProperty property)
    {
        Rect labelRect = new Rect(position.x , position.y + offset, position.width/2 - 10, 20);
        Rect varRect = new Rect(position.x + position.width/2, position.y + offset, position.width/2, 20);

        offset += 22;

        EditorGUI.LabelField(labelRect, label);
        EditorGUI.LabelField(varRect, property.FindPropertyRelative(propertyName).floatValue.ToString());
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 22*6;
    }}