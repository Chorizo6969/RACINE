using UnityEngine;

public static class AttributeComportement
{
    public static void AddComportementHuman(string ComponentName, GameObject target)
    {
        string typeName = ComponentName;
        System.Type componentType = System.Type.GetType(typeName);

        if (componentType == null)
        {
            componentType = System.Type.GetType(typeName + ",Assembly-CSharp");
        }

        if (componentType != null && componentType.IsSubclassOf(typeof(MonoBehaviour)))
        {
            if (!target.GetComponent(componentType))
            {
                target.AddComponent(componentType);
            }
        }
    }
}
