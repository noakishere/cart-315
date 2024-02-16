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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //float jumpDir = Input.GetAxis("Jump");
        
        movementInput = new Vector3(horizontal, 0, vertical).normalized;


        float jumpAxis = Input.GetAxis("Jump");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = movementInput * speed * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPos);

        //if(movement != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        //    rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        //}

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }
}
