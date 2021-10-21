using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    public GameObject cleanPlatform;

    private PlayerController playerController;
    private float platformScrollingSpeed {get;set;}

    // Start is called before the first frame update
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        platformScrollingSpeed = 200f;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * platformScrollingSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = transform.position + Vector3.left * platformScrollingSpeed * Time.deltaTime;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);

            if (gameObject.tag == "InfectedPlatform")
                playerController.playerScore--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "InfectedPlatform" && collision.gameObject.name == "Player")
        {
            Instantiate(cleanPlatform, transform.position, transform.rotation);
            Destroy(gameObject);
            playerController.playerScore += 2;
        }
    }
}
