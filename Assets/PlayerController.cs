using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _lookSensitivity = 3f;

    private PlayerMotor _motor;

    void Start()
    {
        _motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcualte movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right*xMov; //(1, 0, 0), 1 is multipled by -, 0, or 1.
        Vector3 moveVertical = transform.forward*zMov;

        // Final Velocity Vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized*_speed;
            //normalized means get a length of 1 velocity, then multiply by speed

        // Apply Movement
        _motor.Move(velocity);

        // Calculate rotation as a 3D vector - player rotates around Y axis, but camera will rotate around X
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * _lookSensitivity;

        // Apply rotation
        _motor.Rotate(rotation);


        // Calculate camera Rotation rotation as a 3D vector - up and down
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * _lookSensitivity;

        // Apply rotation
        _motor.RotateCamera(cameraRotation);

    }
}
