using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverCamara : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f;

    private Vector3 cameraRotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotaci�n de la c�mara con el rat�n
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        cameraRotation.x -= mouseY;
        cameraRotation.y += mouseX;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90f, 90f); // Limitar la rotaci�n vertical
        transform.rotation = Quaternion.Euler(cameraRotation);
    }
}
