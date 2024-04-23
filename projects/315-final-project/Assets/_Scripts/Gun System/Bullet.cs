using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float deathTimer = 5.0f;
    [SerializeField] private float bulletSpeed = 20f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from bullet prefab!");
        }
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        // Force application removed from here
        transform.parent = null;
        Destroy(gameObject, deathTimer);
    }

    public void test()
    {
        Debug.Log("hello");
    }

    public void Initialize(Vector3 shootDirection, float force = 20f)
    {
        //rb = GetComponent<Rigidbody>();
        rb.AddForce(shootDirection * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject); // Destroy bullet on collision
    }
}
