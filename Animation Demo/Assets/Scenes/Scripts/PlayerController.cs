using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Model components
    CharacterController controller;
    Animator animator;
    Vector3 moveDirection = Vector3.zero;

    // Movement Variables
    float speed = 4.0f;
    float rotationSpeed = 20.0f;
    float rotation = 0.0f;

    // Get controller and animation components
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Check for Movement methods
    void Update()
    {
        MoveCharacter();
        Waving();
    }

    // Player movement (walking)
    void MoveCharacter()
    {
            if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
            {
                // Blend tree variables
                animator.SetBool("IsRunning", true);
                animator.SetInteger("AnimCondition", 1);
                // Set player to move forward
                moveDirection = new Vector3(0, 0, 2);
                moveDirection *= Input.GetAxis("Vertical") * speed * Time.deltaTime;
                moveDirection = transform.TransformDirection(moveDirection);
                controller.Move(moveDirection * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                // Blend tree variables 
                animator.SetBool("IsRunning", false);
                animator.SetInteger("AnimCondition", 0);
                // Player stops moving
                moveDirection = new Vector3(0, 0, 0);
            }
        // Allow player to turn in another direction
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Player movement (Waving)
    void Waving()
    {
        if (Input.GetKey(KeyCode.E))
        {
            // Blend tree variables
            animator.SetBool("IsWaving", true);
            animator.SetInteger("AnimCondition", 2);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Blend tree variables
            animator.SetBool("IsWaving", false);
            animator.SetInteger("AnimCondition", 0);
        }
    }
}