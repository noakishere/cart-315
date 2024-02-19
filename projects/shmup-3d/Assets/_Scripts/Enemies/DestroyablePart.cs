using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyablePart : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticleSystem;
    private void Start()
    {
        Debug.Log("IM ALIVE");
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("HELLO");
        if(collision.gameObject.layer == 9)
        {
            Instantiate(bloodParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
