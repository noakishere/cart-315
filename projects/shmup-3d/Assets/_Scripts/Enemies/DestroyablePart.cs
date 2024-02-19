using UnityEngine;

public class DestroyablePart : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("HELLO");
        if(collision.gameObject.layer == 9)
        {
            ScoreManager.Instance.UpdateScore(20);
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Instantiate(bloodParticleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
