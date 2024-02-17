using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float deathTimer;

    [SerializeField] private float shootingForce;

    Rigidbody rb;

    [SerializeField] private Transform parentGun;

    void Start()
    {
        rb = transform.gameObject.GetComponent<Rigidbody>();

        Debug.Log("HELLO");
        parentGun = transform.parent.parent;


        Destroy(gameObject, deathTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(parentGun.forward * shootingForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
