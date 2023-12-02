using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //Esto hace que si tengo un objeto con este Script, va a agregar directamente el character controller
public class PlayerController : MonoBehaviour
{
    [Header ("Camara")]
    public Camera playerCamera; //Variable para la camara del jugador

    [Header ("General")]
    public float gravity = -20f; //Valor de la gravedad
    public float rotationSensibility = 100f; //Variable para la sensibilidad de la camara
    
    [Header ("Movimiento jugador")]
    public float walkSpeed = 5f; //Velocidad del jugador
    public float runSpeed = 10f; //Velocidad corriendo

    [Header ("Salto")]
    public float jumpHeight = 1.9f; //Valor del salto

    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero; //Movimiento del jugador que inicializa en cero
    Vector3 rotationInput = Vector3.zero; //Variable para la rotación de la camara
    CharacterController controlador;

    private void Awake()
    {
        controlador = GetComponent<CharacterController>();
    }

    private void Player_Movement()
    {
        if(controlador.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            if(Input.GetButton("Sprint"))
            {
                moveInput=transform.TransformDirection(moveInput)*runSpeed;
            }
            else
            {
                moveInput=transform.TransformDirection(moveInput)*walkSpeed;
            }
            
            if(Input.GetButtonDown("Jump")){
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        moveInput.y += gravity * Time.deltaTime;

        controlador.Move(moveInput * Time.deltaTime);
    }

    private void Camera_Movement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotationInput = new Vector3(Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime, Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime, 0f);
        
        cameraVerticalAngle = cameraVerticalAngle + rotationInput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);
        
        transform.Rotate(Vector3.up * rotationInput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        Player_Movement();
        Camera_Movement();
    }
}
