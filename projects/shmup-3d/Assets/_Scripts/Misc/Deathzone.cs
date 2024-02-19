using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            other.gameObject.GetComponent<DestroyablePart>().KillEnemy();
            PlayerHealth.Instance.UpdateHealth(-10);
        }
    }
}
