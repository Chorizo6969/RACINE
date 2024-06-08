using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristCosmique : MonoBehaviour
{
    public GameObject HUMANPLANT;
    public Vector3 startVector;

    void Update()
    {
        Quaternion quaternion2 = this.transform.rotation;
        Quaternion quaternion1 = HUMANPLANT.transform.rotation;

        Quaternion inverse = Quaternion.Inverse(quaternion2);

        Quaternion quaternion3 = quaternion1 * inverse;


        this.transform.rotation = quaternion3;
    }
}