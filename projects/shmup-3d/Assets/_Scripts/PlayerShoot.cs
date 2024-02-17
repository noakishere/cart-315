using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newProjectile = Instantiate(projectile, gunTransform.position, Quaternion.identity);
            newProjectile.transform.parent = gunTransform;
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce()
    }

    
}
