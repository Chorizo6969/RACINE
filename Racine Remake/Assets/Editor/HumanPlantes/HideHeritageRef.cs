#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(NoJobGestion), true)]
public class HideHeritageRef : Editor
{
    public override void OnInspectorGUI()
    {
        var targetType = target.GetType();

        if (targetType == typeof(NoJobGestion))
        {
            DrawDefaultInspector(); // Si on édite un Parent, on affiche tout normalement
        }
        else
        {
            serializedObject.Update();

            SerializedProperty prop = serializedObject.GetIterator();

            bool enterChildren = true;
            while (prop.NextVisible(enterChildren))
            {
                enterChildren = false;


                if (IsDeclaredInClass(prop, typeof(NoJobGestion))) // Exclure les champs définis dans la classe Parent
                    continue;

                EditorGUILayout.PropertyField(prop, true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

    private bool IsDeclaredInClass(SerializedProperty property, System.Type classType)
    {
        string propName = property.name;

        var field = classType.GetField(propName,
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public);

        return field != null;
    }
}
#endif