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

        if (GUILayout.Button("G�n�rer description de personnalit�"))
        {
            if (HumanEnumExtensions.DefaultPersonalityDescriptions.TryGetValue(personalitySO.PersonalityName, out string desc))
            {
                SerializedProperty descProp = serializedObject.FindProperty("_description");
                descProp.stringValue = desc;
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                Debug.LogError($"Aucune description trouv�e pour {personalitySO.PersonalityName}");
            }
        }
    }
}
