using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    private BoxCollider2D platformCollider { get; set; }
    private Rigidbody2D platformRigidbody { get; set; }
    private float platformScrollingSpeed {get;set;}

    // Start is called before the first frame update
    private void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
        platformRigidbody = GetComponent<Rigidbody2D>();
        platformScrollingSpeed = -2f;

        platformRigidbody.velocity = new Vector3(platformScrollingSpeed, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
            Destroy(gameObject);
    }
}
