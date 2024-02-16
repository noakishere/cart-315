using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float deathTimer;

    [SerializeField] private float shootingForce;

    Rigidbody rb;

    void Start()
    {
        rb = transform.GetChild(0).gameObject.GetComponent<Rigidbody>();

        Destroy(gameObject, deathTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * shootingForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
