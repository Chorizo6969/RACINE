using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HumanPersonalitySO))]
public class HumanPersonalitySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        HumanPersonalitySO personalitySO = (HumanPersonalitySO)target;

        GUILayout.Space(25);

        if (GUILayout.Button("Générer description de personnalité"))
        {
            if (HumanEnumExtensions.DefaultPersonalityDescriptions.TryGetValue(personalitySO.PersonalityName, out string desc))
            {
                SerializedProperty descProp = serializedObject.FindProperty("_description");
                descProp.stringValue = desc;
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                Debug.LogError($"Aucune description trouvée pour {personalitySO.PersonalityName}");
            }
        }
    }
}
