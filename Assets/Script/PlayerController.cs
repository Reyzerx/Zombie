using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float runSpeed = 6f;
    private float oldSpeed;

    [SerializeField]
    private float mouseSensitivityX = 3f;
    [SerializeField]
    private float mouseSensitivityY = 3f;

    private PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        oldSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        //Calculer la vélocité du mouvement du joueur
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        //On calcule la rotation du joueur en un Vector3
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        motor.Rotate(rotation);

        //On calcule la rotation de la camera en un Vector3
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY;

        motor.RotateCamera(cameraRotation);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = oldSpeed;
        }
    }
}
