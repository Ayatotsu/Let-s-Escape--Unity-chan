using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    private Animator animator;
    private bool isMoving;
    public int rotationSpeed = 5;
    public int movementSpeed = 5;



    public int jumpHeight;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float gravity = 9.81f;

    public Vector3 velocity;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();    
    }
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isMoving = vertical+horizontal != 0 ? true : false;
        animator.SetFloat("Velocity", vertical);
        animator.SetBool("isMoving", isMoving);

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }


        velocity.y -= gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);


    }


}
