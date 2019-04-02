using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{
    [CustomEditor(typeof(DisplayWinLoseCondition)), CanEditMultipleObjects]
    public class DisplayWinLoseConditionEditor : Editor
    {

        public SerializedProperty
            enum_Condition,
            enum_Status,
            intVariables_prop,
            intValue_prop,
            floatVariables_prop,
            floatValue_prop,
            boolVariables_prop,
            boolValue_prop,
            stringVariables_prop,
            stringValue_prop,
            delayExecute_prop,
            canvasdialog_prop
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            enum_Condition = serializedObject.FindProperty("ConditionType");
            enum_Status = serializedObject.FindProperty("VariableType");
            intVariables_prop = serializedObject.FindProperty("IntVariables");
            intValue_prop = serializedObject.FindProperty("IntValue");
            floatVariables_prop = serializedObject.FindProperty("FloatVariables");
            floatValue_prop = serializedObject.FindProperty("FloatValue");
            boolVariables_prop = serializedObject.FindProperty("BoolVariables");
            boolValue_prop = serializedObject.FindProperty("BoolValue");
            stringVariables_prop = serializedObject.FindProperty("StringVariables");
            stringValue_prop = serializedObject.FindProperty("StringValue");
            delayExecute_prop = serializedObject.FindProperty("DelayExecute");
            canvasdialog_prop = serializedObject.FindProperty("CanvasDialog");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enum_Condition);

            EditorGUILayout.PropertyField(enum_Status);

            DisplayTextVar.CVariableType st = (DisplayTextVar.CVariableType)enum_Status.enumValueIndex;

            switch (st)
            {
                case DisplayTextVar.CVariableType.intVar:
                    EditorGUILayout.PropertyField(intVariables_prop, new GUIContent("IntVariables"));
                    EditorGUILayout.PropertyField(intValue_prop, new GUIContent("IntValue"));
                    break;
                case DisplayTextVar.CVariableType.floatVar:
                    EditorGUILayout.PropertyField(floatVariables_prop, new GUIContent("FloatVariables"));
                    EditorGUILayout.PropertyField(floatValue_prop, new GUIContent("FloatValue"));
                    break;
                case DisplayTextVar.CVariableType.stringVar:
                    EditorGUILayout.PropertyField(stringVariables_prop, new GUIContent("StringVariables"));
                    EditorGUILayout.PropertyField(stringValue_prop, new GUIContent("StringValue"));
                    break;
                case DisplayTextVar.CVariableType.boolVar:
                    EditorGUILayout.PropertyField(boolVariables_prop, new GUIContent("BoolVariables"));
                    EditorGUILayout.PropertyField(boolValue_prop, new GUIContent("BoolValue"));
                    break;
            }

            EditorGUILayout.PropertyField(delayExecute_prop, new GUIContent("DelayExecute"));
            EditorGUILayout.PropertyField(canvasdialog_prop, new GUIContent("CanvasDialog"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}