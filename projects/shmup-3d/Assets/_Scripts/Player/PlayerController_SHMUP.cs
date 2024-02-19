using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController_SHMUP : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedModifier;
    [SerializeField] private float rotationSpeed;

    private Vector3 movementInput;

    Rigidbody rb;
    private float horizontalMovementInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        movementInput = new Vector3(horizontal, 0, 0).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 movement = movementInput * speed * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPos);
    }
}
