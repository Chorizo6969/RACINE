using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui g�re le contr�le de la cam�ra.
/// </summary>
public class ControlCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _goParentTransform; // R�f�rence � la position du parent de la cam�ra
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _gameObjectParent;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;
    [SerializeField] private Bounds _cameraLimits;

    private bool _isLeftMouseButtonPress;

    public Vector2 MouseDelta;
    public float ZoomMax;
    public float ZoomMin;

    private void Start()
    {
        _goParentTransform = _gameObjectParent.transform;
        _isLeftMouseButtonPress = false;
    }

    /// <summary>
    /// Fonction permettant de zoomer avec la cam�ra
    /// </summary>
    /// <param name="_context"></param>
    public void OnZoomP(InputAction.CallbackContext _context)
    {
        if (_camera.orthographicSize >= ZoomMin)
        {
            _camera.orthographicSize -= 0.5f;
            if (_camera.orthographicSize <= ZoomMin)
            {
                _camera.orthographicSize = ZoomMin;
            }
        }
    }
    public void OnZoomM(InputAction.CallbackContext _context)
    {
        if (_camera.orthographicSize <= ZoomMax)
        {
            _camera.orthographicSize += 0.5f;
            if (_camera.orthographicSize >= ZoomMax)
            {
                _camera.orthographicSize = ZoomMax;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            _isLeftMouseButtonPress = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (_context.canceled)
        {
            _isLeftMouseButtonPress = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        if (!_isLeftMouseButtonPress) return;
        Vector2 mouseMovement = Mouse.current.delta.ReadValue();  // R�cup�rer les mouvements de la souris

        MouseDelta += _moveSpeed * Time.deltaTime * mouseMovement; // Convertir le mouvement de la souris en Vector3

        Vector3 mouseScreen = new Vector3(-MouseDelta.x, 0, -MouseDelta.y);
        Vector3 mouseIso = Quaternion.Euler(0, 45, 0) * mouseScreen;
        Vector3 targetPosition = _goParentTransform.position + mouseIso;

        _goParentTransform.position = _cameraLimits.ClosestPoint(targetPosition);

        MouseDelta = Vector2.zero;   // R�initialiser le mouvement de la souris pour le frame suivant
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_cameraLimits.center, _cameraLimits.size);
    }
}