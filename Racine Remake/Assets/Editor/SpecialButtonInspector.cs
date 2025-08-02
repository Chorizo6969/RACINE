using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(SpecialButton), false)]
[CanEditMultipleObjects]
public class SpecialButtonInspector : ButtonEditor
{
    private bool _hoverFoldout;
    private bool _deselectFoldout;
    private bool _disableFoldout;
    private bool _enableFoldout;

    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();

        base.OnInspectorGUI();

        EditorGUILayout.Space();

        SpecialButton specialButton = (SpecialButton)target;

        #region Unity Events

        _hoverFoldout = EditorGUILayout.Foldout(_hoverFoldout, "Hover");
        EditorGUILayout.Space();

        if (_hoverFoldout)
        {
            SerializedProperty onHover = serializedObject.FindProperty("OnHoverEvent");
            EditorGUILayout.PropertyField(onHover, new GUIContent("On Hover"));
        }

        EditorGUILayout.Space();

        _deselectFoldout = EditorGUILayout.Foldout(_deselectFoldout, "Deselect");
        EditorGUILayout.Space();

        if (_deselectFoldout)
        {
            SerializedProperty onDeselected = serializedObject.FindProperty("OnDeselectEvent");
            EditorGUILayout.PropertyField(onDeselected, new GUIContent("On Deselect"));
        }

        EditorGUILayout.Space();

        _disableFoldout = EditorGUILayout.Foldout(_disableFoldout, "Disable");
        EditorGUILayout.Space();

        if(_disableFoldout)
        {
            SerializedProperty onDisabled = serializedObject.FindProperty("OnDisabledEvent");
            EditorGUILayout.PropertyField(onDisabled, new GUIContent("On Disable"));
        }

        EditorGUILayout.Space();

        _enableFoldout = EditorGUILayout.Foldout(_enableFoldout, "Enable");
        EditorGUILayout.Space();

        if (_enableFoldout)
        {
            SerializedProperty onEnabled = serializedObject.FindProperty("OnEnabledEvent");
            EditorGUILayout.PropertyField(onEnabled, new GUIContent("On Enable"));
        }

        EditorGUILayout.Space();

        #endregion

        if (GUI.changed) serializedObject.ApplyModifiedProperties();
    }
}
