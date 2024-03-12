using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamera : MonoBehaviour
{
    public Camera Camera;
    public Transform GOParentTransform;
    private Vector2 mouseDelta;
    public float moveSpeed;
    public GameObject GameObjectParent;
    public bool isLeftMouseButtonPress;
    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    private void Start()
    {
        GOParentTransform = GameObjectParent.transform;
        isLeftMouseButtonPress = false;
    }

    public void OnZoomP(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize >= 1.5f)
        {
            Camera.GetComponent<Camera>().orthographicSize -= 0.06f;
            if (Camera.GetComponent<Camera>().orthographicSize <= 1.5f)
            {
                Camera.GetComponent<Camera>().orthographicSize = 1.5f;
            }
        }
    }

    public void OnZoomM(InputAction.CallbackContext _context)
    {
        if (Camera.GetComponent<Camera>().orthographicSize <= 5f)
        {
            Camera.GetComponent<Camera>().orthographicSize += 0.06f;
            if (Camera.GetComponent<Camera>().orthographicSize >= 5f)
            {
                Camera.GetComponent<Camera>().orthographicSize = 5f;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            isLeftMouseButtonPress = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (_context.canceled)
        {
            isLeftMouseButtonPress = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (isLeftMouseButtonPress && Camera.GetComponent<Camera>().orthographicSize != 5f)
        {

            if (GOParentTransform.position.x < minX)
            {
                GOParentTransform.transform.position = new Vector3(minX, GOParentTransform.position.y, GOParentTransform.position.z);
            }
            if (GOParentTransform.position.x > maxX)
            {
                GOParentTransform.transform.position = new Vector3(maxX, GOParentTransform.position.y, GOParentTransform.position.z);
            }
            if (GOParentTransform.position.z < minZ)
            {
                GOParentTransform.transform.position = new Vector3(GOParentTransform.position.x, GOParentTransform.position.y, minZ);
            }
            if (GOParentTransform.position.z > maxZ)
            {
                GOParentTransform.transform.position = new Vector3(GOParentTransform.position.x, GOParentTransform.position.y, maxZ);
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