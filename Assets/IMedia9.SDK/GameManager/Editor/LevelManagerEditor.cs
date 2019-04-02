using UnityEditor;
using UnityEngine;

namespace IMedia9
{
    [CustomEditor(typeof(LevelManager)), CanEditMultipleObjects]
    public class LevelManagerEditor : Editor
    {

        public SerializedProperty
            LoadingType_prop,
            WaitSecond_prop,
            NextSceneName_prop,
            WithLoadingScreen_prop,
            NextSceneIndex_prop,
            CollisionType_prop,
            ObjectTag_prop
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            LoadingType_prop = serializedObject.FindProperty("LoadingType");
            WaitSecond_prop = serializedObject.FindProperty("WaitSecond");
            NextSceneName_prop = serializedObject.FindProperty("NextSceneName");
            WithLoadingScreen_prop = serializedObject.FindProperty("WithLoadingScreen");
            NextSceneIndex_prop = serializedObject.FindProperty("NextSceneIndex");
            CollisionType_prop = serializedObject.FindProperty("CollisionType");
            ObjectTag_prop = serializedObject.FindProperty("ObjectTag");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(LoadingType_prop);

            LevelManager.CLoadingType st = (LevelManager.CLoadingType)LoadingType_prop.enumValueIndex;

            switch (st)
            {
                case LevelManager.CLoadingType.DelayOnly:
                    EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                    EditorGUILayout.PropertyField(WaitSecond_prop, new GUIContent("WaitSecond"));
                    break;
                case LevelManager.CLoadingType.DelayAndLoading:
                    EditorGUILayout.PropertyField(NextSceneIndex_prop, new GUIContent("NextSceneIndex"));
                    EditorGUILayout.PropertyField(WaitSecond_prop, new GUIContent("WaitSecond"));
                    break;
                case LevelManager.CLoadingType.ClickOnly:
                    EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                    break;
                case LevelManager.CLoadingType.ClickAndLoading:
                    EditorGUILayout.PropertyField(NextSceneIndex_prop, new GUIContent("NextSceneIndex"));
                    break;
                case LevelManager.CLoadingType.CollisionOnly:
                    EditorGUILayout.PropertyField(NextSceneName_prop, new GUIContent("NextSceneName"));
                    EditorGUILayout.PropertyField(CollisionType_prop, new GUIContent("CollisionType"));
                    EditorGUILayout.PropertyField(ObjectTag_prop, new GUIContent("ObjectTag"));
                    break;
                case LevelManager.CLoadingType.CollisionAndLoading:
                    EditorGUILayout.PropertyField(NextSceneIndex_prop, new GUIContent("NextSceneIndex"));
                    EditorGUILayout.PropertyField(CollisionType_prop, new GUIContent("CollisionType"));
                    EditorGUILayout.PropertyField(ObjectTag_prop, new GUIContent("ObjectTag"));
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}