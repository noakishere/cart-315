using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private Vector3 targetPosition;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedModifier;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = destination.position;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Move towards the current target position
        Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    public void SetDestination(Transform destination)
    {
        this.destination = destination;
    }
}
