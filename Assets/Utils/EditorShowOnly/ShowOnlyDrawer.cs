﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;


[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        string valueStr;

        switch (prop.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            case SerializedPropertyType.ObjectReference:
                if (prop.objectReferenceValue)
                    valueStr = prop.objectReferenceValue.name;
                else
                    valueStr = "Not Yet Assigned";
                break;
            default:
                valueStr = "(not supported)";
                break;
        }

        EditorGUI.LabelField(position,label.text, valueStr);
    }
}
#endif