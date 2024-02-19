using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedModifier;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool jumpRequested = false;
    [SerializeField] private LayerMask groundLayer; // Optional, to specify what is considered ground
    [SerializeField] private Transform groundCheck; // A point at the character's feet to check for ground
    [SerializeField] private float groundCheckRadius = 0.5f; // Radius of the ground check


    private Vector3 movementInput;

    Rigidbody rb;
    private float horizontalMovementInput;
    private float verticalMovementInput;
    private float horizontalRotationInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        horizontalRotationInput = Input.GetAxis("Mouse X");
        float joystickInput = Input.GetAxis("RightJoystickHorizontal");
        joystickInput = ApplyDeadZone(joystickInput, 0.1f);

        horizontalRotationInput += joystickInput;

        float vertical = Input.GetAxis("Vertical");
        //float jumpDir = Input.GetAxis("Jump");
        
        movementInput = new Vector3(horizontal, 0, vertical).normalized;


        float jumpAxis = Input.GetAxis("Jump");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        //horizontalRotationInput = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        Vector3 movement = movementInput * (speed + speedModifier) * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPos);

        //if (movement != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        //    rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        //}

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }

        // Calculate rotation amount
        float rotationAmount = horizontalRotationInput * rotationSpeed * Time.fixedDeltaTime;

        // Apply rotation to the Rigidbody
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotationAmount, 0));
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


    float ApplyDeadZone(float input, float deadZone)
    {
        if (Mathf.Abs(input) < deadZone)
        {
            return 0; // Input is within the dead zone, ignore it
        }
        else
        {
            // Input is outside the dead zone, optionally adjust to start at 0
            return (Mathf.Abs(input) - deadZone) * Mathf.Sign(input) / (1 - deadZone);
        }
    }
}
