using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Mouvement
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Rotation
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        cam.transform.Rotate(-cameraRotation);
    }

    //Rotation Camera
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
}
