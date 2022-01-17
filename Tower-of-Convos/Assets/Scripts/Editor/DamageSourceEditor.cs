using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(DamageSource))]
public class DamageSourceEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //TODO: Fix Me
        SerializedProperty damageAmount = property.FindPropertyRelative("amount");
        damageAmount.floatValue = EditorGUILayout.FloatField("Damage amount", damageAmount.floatValue);
    }
}
