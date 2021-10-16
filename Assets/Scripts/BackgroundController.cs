using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private BoxCollider2D backgroundCollider { get; set; }
    private Rigidbody2D backgroundRigidbody { get; set; }
    private float backgroundWidth { get; set; }
    private float backgroundScrollingSpeed { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundRigidbody = GetComponent<Rigidbody2D>();

        backgroundWidth = backgroundCollider.size.x;
        backgroundScrollingSpeed = -2f;
        backgroundCollider.enabled = false;
        backgroundRigidbody.velocity = new Vector3(backgroundScrollingSpeed, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < -backgroundWidth)
        {
            Vector3 scrollBackPosition = new Vector3(backgroundWidth * 2f, 0, 0);
            transform.position = transform.position + scrollBackPosition;
        }
    }
}
