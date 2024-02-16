using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Game object components
    private Rigidbody2D rb;

    [Header("General movement stuff")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementSpeedModifier;

    [SerializeField] private bool canMove;

    // tracks input for movement
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (movementSpeed + movementSpeedModifier) * Time.fixedDeltaTime);
    }


    // Setters
    public void SetModifier(float modifierValue)
    {
        movementSpeedModifier += modifierValue;
    }

    public void SetMoveRules(bool canMove)
    {
        this.canMove = canMove;
    }
}
