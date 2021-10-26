using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float maskSpeed = 2500f;
    private Rigidbody2D maskRigidbody { get; set; }

    private void Start()
    {
        maskRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        maskRigidbody.velocity = transform.right * maskSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
