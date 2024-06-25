using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// script qui s'occupe du drag n drop des bâtiments
/// </summary>
public class dragAndDropBuilding : MonoBehaviour
{
    /// <summary>
    /// Référence du batiment en train d'être placé
    /// </summary>
    [field : SerializeField] public GameObject BOUGE { get; set; }

    /// <summary>
    /// booléen qui renvoit si l'on a cliqué sur un bouton pour mettre un batiment
    /// </summary>
    [field : SerializeField] public bool HasClickOnBuildingButtonInstance {  get; set; }

    public static dragAndDropBuilding instance;

    public GameObject PPAANNEELL;

    public float HauteurSpawn = -1;

    public LayerMask LayerMask;

    public GameObject PanelBuildingTuto;

    private void Awake()
    {
        instance = this;
    }

    public void OnLeftClick(InputAction.CallbackContext callBackContext)
    {
        if (callBackContext.canceled && BOUGE != null)
        {
            if (BOUGE.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().isPlacable)
            {
                BOUGE.GetComponent<BuildingCanvas>().placeOrNot = true;
                HasClickOnBuildingButtonInstance = false;
                BOUGE.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().SetBox();
                BOUGE.GetComponent<BuildingCanvas>().Building.GetComponent<PlaceOuPasPlace>().enabled = false;
                BOUGE.GetComponent<BuildingCanvas>().NormalMat();
                BOUGE.GetComponent <BuildingCanvas>().DropBuilding();
                PPAANNEELL.SetActive(true);
                PanelBuildingTuto.SetActive(false);
                BOUGE = null;
            }
        }
    }

    public void OnEscapeCancelBuild(InputAction.CallbackContext callBackContext)
    {
        if (callBackContext.started && BOUGE != null)
        {
            if (BOUGE.GetComponent<BuildingCanvas>().FirstPlacement)
            {
                PPAANNEELL.SetActive(true);
                Destroy(BOUGE);
                BOUGE = null;
                PanelBuildingTuto.SetActive(false);
            }
        }
    }
    public void BuildRotation(InputAction.CallbackContext callBackContext)
    {
        if (callBackContext.started && BOUGE != null)
        {
            BOUGE.GetComponent<BuildingCanvas>().Building.transform.Rotate(new Vector3(0, 90, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HasClickOnBuildingButtonInstance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, Mathf.Infinity, 1 << 6);
            if (BOUGE != null)
            {
                if (hitInfo.collider != null)
                {
                    //if (hitInfo.collider.gameObject.layer == 6)
                    //{
                        BOUGE.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                    //}
                }
            }
            //Debug.DrawRay(ray.origin, ray.direction*100, Color.red);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ClickOnButtonInstancier()
    {
        HasClickOnBuildingButtonInstance = true;
        StartCoroutine(Wait());
        BOUGE.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        BOUGE.transform.position += new Vector3(0, HauteurSpawn,0);
    }
}