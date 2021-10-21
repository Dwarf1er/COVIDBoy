using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private int backgroundWidth;
    private float backgroundScrollingSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        backgroundWidth = 1920;
        backgroundScrollingSpeed = 200f;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = transform.position + Vector3.left * backgroundScrollingSpeed * Time.deltaTime;

        if (transform.position.x < -backgroundWidth)
        {
            Vector3 scrollBackPosition = new Vector3(backgroundWidth * 3f, 0, 0);
            transform.position = transform.position + scrollBackPosition;
        }
    }
}
