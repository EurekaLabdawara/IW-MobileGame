using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{
    [CustomEditor(typeof(DisplayHealthCube)), CanEditMultipleObjects]
    public class DisplayHealthCubeEditor : Editor
    {

        public SerializedProperty
            enum_Status,
            intVariables_prop,
            floatVariables_prop,
            boolVariables_prop,
            stringVariables_prop,
            displaytext_prop,
            maincamera_prop,
            maincanvas_prop
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            enum_Status = serializedObject.FindProperty("VariableType");
            intVariables_prop = serializedObject.FindProperty("IntVariables");
            floatVariables_prop = serializedObject.FindProperty("FloatVariables");
            boolVariables_prop = serializedObject.FindProperty("BoolVariables");
            stringVariables_prop = serializedObject.FindProperty("StringVariables");
            displaytext_prop = serializedObject.FindProperty("DisplaySlider");
            maincamera_prop = serializedObject.FindProperty("MainCamera");
            maincanvas_prop = serializedObject.FindProperty("MainCanvas");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enum_Status);

            DisplayTextVar.CVariableType st = (DisplayTextVar.CVariableType)enum_Status.enumValueIndex;

            EditorGUILayout.PropertyField(displaytext_prop, new GUIContent("DisplaySlider"));

            switch (st)
            {
                case DisplayTextVar.CVariableType.intVar:
                    EditorGUILayout.PropertyField(intVariables_prop, new GUIContent("IntVariables"));
                    break;
                case DisplayTextVar.CVariableType.floatVar:
                    EditorGUILayout.PropertyField(floatVariables_prop, new GUIContent("FloatVariables"));
                    break;
                case DisplayTextVar.CVariableType.stringVar:
                    EditorGUILayout.PropertyField(stringVariables_prop, new GUIContent("StringVariables"));
                    break;
                case DisplayTextVar.CVariableType.boolVar:
                    EditorGUILayout.PropertyField(boolVariables_prop, new GUIContent("BoolVariables"));
                    break;
            }

            EditorGUILayout.PropertyField(maincamera_prop, new GUIContent("MainCamera"));
            EditorGUILayout.PropertyField(maincanvas_prop, new GUIContent("MainCanvas"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}