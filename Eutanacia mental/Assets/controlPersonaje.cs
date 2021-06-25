using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPersonaje : MonoBehaviour
{
    CharacterController characterController;
    [Header("Opciones de personaje")]
    public float caminar = 1.0f; 
    public float saltar = 8.0f;
    public float gravedad = 20.0f;

    [Header("Opciones de camara")]
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;

    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    

    


    private Vector3 move = Vector3.zero;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked; 
        
        
    }

    void Update()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        

        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

        transform.Rotate(0, h_mouse, 0);


        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

                move = transform.TransformDirection(move) * caminar;

            if (Input.GetKey(KeyCode.Space))

                move.y = saltar;
        }
        move.y -= gravedad * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
