using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui gère le contrôle de la caméra.
/// </summary>
public class ControlCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;
    [SerializeField] private Bounds _cameraLimits;
    [SerializeField] private float _zoomMax;
    [SerializeField] private float _zoomMin;

    private bool _isLeftMouseButtonPress;
    private Vector2 _mouseDelta;

    public void OnZoomP(InputAction.CallbackContext _context)
    {
        if (_camera.orthographicSize >= _zoomMin)
        {
            _camera.orthographicSize -= 0.5f;
            if (_camera.orthographicSize <= _zoomMin)
            {
                _camera.orthographicSize = _zoomMin;
            }
        }
    }
    public void OnZoomM(InputAction.CallbackContext _context)
    {
        if (_camera.orthographicSize <= _zoomMax)
        {
            _camera.orthographicSize += 0.5f;
            if (_camera.orthographicSize >= _zoomMax)
            {
                _camera.orthographicSize = _zoomMax;
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
        Vector2 mouseMovement = Mouse.current.delta.ReadValue();  // Récupérer les mouvements de la souris

        _mouseDelta += _moveSpeed * Time.deltaTime * mouseMovement; // Convertir le mouvement de la souris en Vector3

        Vector3 mouseScreen = new Vector3(-_mouseDelta.x, 0, -_mouseDelta.y);
        Vector3 mouseIso = Quaternion.Euler(0, 45, 0) * mouseScreen;
        Vector3 targetPosition = gameObject.transform.position + mouseIso;

        gameObject.transform.position = _cameraLimits.ClosestPoint(targetPosition);

        _mouseDelta = Vector2.zero;   // Réinitialiser le mouvement de la souris pour le frame suivant
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_cameraLimits.center, _cameraLimits.size);
    }
}