using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HumanJobSO))]
public class HumanJobSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        HumanJobSO JobSO = (HumanJobSO)target;

        GUILayout.Space(25);

        if (GUILayout.Button("G�n�rer description automatique"))
        {
            if (HumanEnumExtensions.DefaultJobDescriptions.TryGetValue(JobSO.JobName, out string desc))
            {
                SerializedProperty descProp = serializedObject.FindProperty("_description");
                descProp.stringValue = desc;
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                Debug.LogError($"Aucune description trouv�e pour {JobSO.JobName}");
            }
        }
    }
}
