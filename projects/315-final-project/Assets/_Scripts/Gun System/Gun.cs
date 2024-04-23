using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunTransform;

    public float recoilTime = 0.5f; // 0.5 seconds of recoil time

    private float lastShotTime = 0f; // Time since last shot

    [SerializeField] private float bulletSpeed;

    [SerializeField] private VisualEffect gunVFX;

    // Start is called before the first frame update
    void Start()
    {
        //gunVFX.SetFloat("FireballSize", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastShotTime >= recoilTime)
        {

            Fire();
            lastShotTime = Time.time;

            // gun vfx animation
            StartCoroutine(AnimateFireballSize());
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile, gunTransform.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Initialize(gunTransform.transform.forward, bulletSpeed);
    }

    IEnumerator AnimateFireballSize()
    {
        float elapsedTime = 0f;
        gunVFX.SetFloat("FireballSize", 0); // Start with 0 when the player cannot shoot

        while (elapsedTime < recoilTime)
        {
            float newSize = Mathf.Lerp(0, 1, elapsedTime / recoilTime);
            gunVFX.SetFloat("FireballSize", newSize);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gunVFX.SetFloat("FireballSize", 1); 
    }

    private void FixedUpdate()
    {
        //rb.AddForce()
    }


}