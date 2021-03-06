﻿using UnityEditor;
using UnityEngine;

namespace IMedia9
{
    [CustomEditor(typeof(GlobalVar)), CanEditMultipleObjects]
    public class GlobalVarEditor : Editor
    {

        public SerializedProperty
            enum_Status,
            intVariables_prop,
            floatVariables_prop,
            boolVariables_prop,
            stringVariables_prop
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            enum_Status = serializedObject.FindProperty("VariableType");
            intVariables_prop = serializedObject.FindProperty("intVariables");
            floatVariables_prop = serializedObject.FindProperty("floatVariables");
            boolVariables_prop = serializedObject.FindProperty("boolVariables");
            stringVariables_prop = serializedObject.FindProperty("stringVariables");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enum_Status);

            DisplayTextVar.CVariableType st = (DisplayTextVar.CVariableType)enum_Status.enumValueIndex;

            switch (st)
            {
                case DisplayTextVar.CVariableType.intVar:
                    EditorGUILayout.PropertyField(intVariables_prop, new GUIContent("intVariables"));
                    break;
                case DisplayTextVar.CVariableType.floatVar:
                    EditorGUILayout.PropertyField(floatVariables_prop, new GUIContent("floatVariables"));
                    break;
                case DisplayTextVar.CVariableType.stringVar:
                    EditorGUILayout.PropertyField(stringVariables_prop, new GUIContent("stringVariables"));
                    break;
                case DisplayTextVar.CVariableType.boolVar:
                    EditorGUILayout.PropertyField(boolVariables_prop, new GUIContent("boolVariables"));
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}