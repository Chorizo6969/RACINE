using UnityEngine;

/// <summary>
/// harvests plants from a field
/// </summary>
public class Harvest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //harvest the field
        if (other.CompareTag("tonk") && transform.position.y == 0.738f)
        {
            //other.GetComponent<PlayerMoney>().EditMoneyAmount(GetComponent<PlantShellValue>().Value);
            gameObject.transform.position -= new Vector3(0, 10, 0);
            Destroy(gameObject, 0.1f);
        }
    }
}