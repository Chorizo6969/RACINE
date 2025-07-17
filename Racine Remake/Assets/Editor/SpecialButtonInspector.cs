using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(SpecialButton), false)]
[CanEditMultipleObjects]
public class SpecialButtonInspector : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpecialButton specialButton = (SpecialButton)target;

        #region Unity Events

        EditorGUILayout.Space();

        SerializedProperty onHover = serializedObject.FindProperty("OnHoverEvent");
        EditorGUILayout.PropertyField(onHover, new GUIContent("On Hover"));

        EditorGUILayout.Space();

        SerializedProperty onDeselected = serializedObject.FindProperty("OnDeselectEvent");
        EditorGUILayout.PropertyField(onDeselected, new GUIContent("On Deselect"));

        EditorGUILayout.Space();

        SerializedProperty onDisabled = serializedObject.FindProperty("OnDisabledEvent");
        EditorGUILayout.PropertyField(onDisabled, new GUIContent("On Disable"));

        EditorGUILayout.Space();

        SerializedProperty onEnabled = serializedObject.FindProperty("OnEnabledEvent");
        EditorGUILayout.PropertyField(onEnabled, new GUIContent("On Enable"));

        EditorGUILayout.Space();

        #endregion

        if (GUI.changed) serializedObject.ApplyModifiedProperties();
    }
}
