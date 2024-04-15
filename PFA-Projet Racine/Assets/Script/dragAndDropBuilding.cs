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
    [field : SerializeField] public bool HasClickOnBuildingButtonInstance {  get; private set; }

    /// <summary>
    /// position de base de la caméra
    /// </summary>
    private Vector3 _startPos;


    private void Start()
    {
        _startPos = transform.position;
    }

    public void OnLeftClick(InputAction.CallbackContext callBackContext)
    {
        if (callBackContext.canceled)
        {
            HasClickOnBuildingButtonInstance = false;
            BOUGE = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HasClickOnBuildingButtonInstance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (BOUGE != null)
            {
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.tag == "tile")
                    {
                        BOUGE.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction*50, Color.red);
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
        transform.position = _startPos;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(Wait());
        BOUGE.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        BOUGE.transform.position += new Vector3(0, 0.7f, 0);
    }
}