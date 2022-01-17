using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(DamageSource))]
public class DamageSourceEditor : PropertyDrawer
{
    private int offset = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        offset = 0;
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        drawProperty("SourceName", "Name", position, property);
        drawProperty("isSingle", "Is Single", position, property);
        if(property.FindPropertyRelative("isSingle").boolValue)
            drawProperty("amount", "Damage Amount", position, property);
        else
            drawProperty("duration", "Duration", position, property);

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
        return 22*3;
    }
}
