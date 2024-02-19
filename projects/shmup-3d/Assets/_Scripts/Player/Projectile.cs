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

        parentGun = transform.parent.parent;


        Destroy(gameObject.transform.parent.gameObject, deathTimer);
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
        //Debug.Log("HELLO FROM PROJECTILE");
    }
}
