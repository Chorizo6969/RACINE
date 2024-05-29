using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui gère le contrôle de la caméra.
/// </summary>
public class ControlCamera : MonoBehaviour
{
    /// <summary>
    /// Référence vers le component caméra.
    /// </summary>
    [SerializeField] private Camera Camera;

    /// <summary>
    /// Référence à la position du parent de la caméra
    /// </summary>
    [SerializeField] private Transform GOParentTransform;

    /// <summary>
    /// Stock les mouvements de la souris
    /// </summary>
    private Vector2 mouseDelta;

    /// <summary>
    /// Vitesse de déplacement de la caméra
    /// </summary>
    [SerializeField] private float moveSpeed;

    /// <summary>
    /// GameObject parent de la caméra
    /// </summary>
    [SerializeField] private GameObject GameObjectParent;

    /// <summary>
    /// Booléen disant si on appuit sur le bouton gauche de la souris
    /// </summary>
    private bool isLeftMouseButtonPress;

    /// <summary>
    /// valeur max de déplacement sur l'axe X
    /// </summary>
    [SerializeField] private float maxX;

    /// <summary>
    /// valeur min de déplacement sur l'axe X
    /// </summary>
    [SerializeField] private float minX;

    /// <summary>
    /// valeur max de déplacement sur l'axe Z
    /// </summary>
    [SerializeField] private float maxZ;

    /// <summary>
    /// valeur min de déplacement sur l'axe Z
    /// </summary>
    [SerializeField] private float minZ;

    public float ZoomMax;
    public float ZoomMin;

    private void Start()
    {
        GOParentTransform = GameObjectParent.transform;
        isLeftMouseButtonPress = false;
    }

    /// <summary>
    /// Fonction permettant de zoomer avec la caméra
    /// </summary>
    /// <param name="_context"></param>
    public void OnZoomP(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize >= ZoomMin)
        {
            Camera.GetComponent<Camera>().orthographicSize -= 0.5f;
            if (Camera.GetComponent<Camera>().orthographicSize <= ZoomMin)
            {
                Camera.GetComponent<Camera>().orthographicSize = ZoomMin;
            }
        }
    }

    /// <summary>
    /// Fonction permettant de dézoomer
    /// </summary>
    /// <param name="_context"></param>
    public void OnZoomM(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize <= ZoomMax)
        {
            Camera.GetComponent<Camera>().orthographicSize += 0.5f;
            if (Camera.GetComponent<Camera>().orthographicSize >= ZoomMax)
            {
                Camera.GetComponent<Camera>().orthographicSize = ZoomMax;
            }
        }
    }

    /// <summary>
    /// Fonction qui permet de déplacer la caméra
    /// </summary>
    /// <param name="_context"></param>
    public void OnMove(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            isLeftMouseButtonPress = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (_context.canceled)
        {
            isLeftMouseButtonPress = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        if (isLeftMouseButtonPress)
        {

            if (GOParentTransform.position.x < minX)
            {
                GOParentTransform.position = new Vector3(minX, GOParentTransform.position.y, GOParentTransform.position.z);
            }
            if (GOParentTransform.position.x > maxX)
            {
                GOParentTransform.position = new Vector3(maxX, GOParentTransform.position.y, GOParentTransform.position.z);
            }
            if (GOParentTransform.position.z < minZ)
            {
                GOParentTransform.position = new Vector3(GOParentTransform.position.x, GOParentTransform.position.y, minZ);
            }
            if (GOParentTransform.position.z > maxZ)
            {
                GOParentTransform.position = new Vector3(GOParentTransform.position.x, GOParentTransform.position.y, maxZ);
            }

            if (GOParentTransform.position.x >= minX && GOParentTransform.position.x <= maxX && GOParentTransform.position.z >= minZ && GOParentTransform.position.z <= maxZ)
            {
                // Récupérer les mouvements de la souris
                Vector2 mouseMovement = Mouse.current.delta.ReadValue();

                // Convertir le mouvement de la souris en Vector3
                mouseDelta += mouseMovement * Time.deltaTime * moveSpeed;

                // Appliquer le mouvement à la position de la caméra
                GOParentTransform.Translate(new Vector3(mouseDelta.x, 0, mouseDelta.y));
                // Réinitialiser le mouvement de la souris pour le frame suivant
                mouseDelta = Vector2.zero;
            }
        }
    }
}