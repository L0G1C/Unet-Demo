using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;


    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private Vector3 _cameraRotation = Vector3.zero;

    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Gets a movement vector from controller
    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    // Get a rotation vector from controller
    public void Rotate(Vector3 rotation)
    {
        _rotation = rotation;
    }

    public void RotateCamera(Vector3 cameraRotation)
    {
        _cameraRotation = cameraRotation;
    }


    // Run every physics iteration (fixed time)
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();
    }


    // Perform movement based on velocity field
    void PerformMovement()
    {
        if (_velocity != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
        }
    }

    // Perform player rotation
    void PerformRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));
    }

    // Perform camera rotation
    void PerformCameraRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));
        if (_cam != null)
        {
            _cam.transform.Rotate(- _cameraRotation);
        }
    }


}
