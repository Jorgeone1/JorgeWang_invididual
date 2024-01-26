using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController charactecontroller;
    [SerializeField] new  private Transform camera;
    [SerializeField] private float speed = 4;
    [SerializeField] private float gravity = -9.8f;
    private Animator animator;
    [SerializeField]private float sprint;
    private float velocidads;
    // Start is called before the first frame update
    void Start()
    {
        charactecontroller = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();
        velocidads = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float movementspeed = 0f;
        float sprintd = 1;
        Vector3 movement = Vector3.zero;
        speed = velocidads;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Realiza alguna acción cuando Shift está presionado
            speed += sprint;
            sprintd = -1;
        }
        if (hor != 0 || ver != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementspeed = Mathf.Clamp01(direction.magnitude) * sprintd;
            direction.Normalize();
            movement = direction * speed * Time.deltaTime;  
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),1);
            
        }

        animator.SetFloat("speedx", movementspeed);
        movement.y += gravity*Time.deltaTime;
        charactecontroller.Move(movement);
    }
}
