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
    public Vector2 mouseDelta;

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

    [SerializeField]
    private Bounds cameraLimits;

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
        if (!isLeftMouseButtonPress) return;

        // Récupérer les mouvements de la souris
        Vector2 mouseMovement = Mouse.current.delta.ReadValue();

        // Convertir le mouvement de la souris en Vector3
        mouseDelta += moveSpeed * Time.deltaTime * mouseMovement;

        Vector3 targetPosition = GOParentTransform.position + new Vector3(mouseDelta.x, 0, mouseDelta.y);

        if (!cameraLimits.Contains(targetPosition))
        {
            targetPosition = cameraLimits.ClosestPoint(targetPosition);
        }

        // Appliquer le mouvement à la position de la caméra
        GOParentTransform.localPosition = targetPosition;

        // Réinitialiser le mouvement de la souris pour le frame suivant
        mouseDelta = Vector2.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(cameraLimits.center, cameraLimits.size);
    }
}