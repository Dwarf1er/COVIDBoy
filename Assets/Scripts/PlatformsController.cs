using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    public GameObject cleanPlatform;
    public GameObject infectedPlatform;

    private float platformScrollingSpeed {get;set;}

    // Start is called before the first frame update
    private void Start()
    {
        platformScrollingSpeed = 200f;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * platformScrollingSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {

            if (gameObject.tag == "InfectedPlatform")
            {
                if(GameObject.FindGameObjectsWithTag("CleanPlatform").Length != 0)
                {
                    GameObject platformSpread = GameObject.FindGameObjectsWithTag("CleanPlatform")[0];
                    GameObject newInfectedPlatform = Instantiate(infectedPlatform, platformSpread.transform.position, platformSpread.transform.rotation);
                    newInfectedPlatform.GetComponent<BoxCollider2D>().enabled = true;
                    newInfectedPlatform.GetComponent<Rigidbody2D>().velocity = Vector2.left * platformScrollingSpeed;
                    Destroy(platformSpread);
                }

                PlayerController.playerScore -= GameController.playerScorePenalty;
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "InfectedPlatform" && collision.gameObject.name == "Player")
        {
            Instantiate(cleanPlatform, transform.position, transform.rotation);
            Destroy(gameObject);

            PlayerController.playerScore += GameController.playerScoreBonus;
        }
    }
}
