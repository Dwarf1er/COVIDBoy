using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody { get; set; }
    private Vector2 playerVelocity { get; set; }
    private bool isPlayerOnGround { get; set; }
    private Vector2 notMoving { get; set; }

    [SerializeField] private float playerMovementSpeed = 15f;

    // Start is called before the first frame update
    private void Start()
    {
        notMoving = Vector2.zero;

        playerVelocity = notMoving;
        isPlayerOnGround = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float playerMovementX = Input.GetAxisRaw("Horizontal");

        Vector2 playerHorizontalMovement = transform.right * playerMovementX;
        Vector2 playerFinalVelocity = playerHorizontalMovement.normalized * playerMovementSpeed;
        playerVelocity = playerFinalVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnGround)
            playerRigidbody.AddForce(Vector3.up * 50, ForceMode2D.Impulse);

        if (playerVelocity != notMoving)
        {
            if (playerMovementX == -1)
                playerRigidbody.velocity = new Vector2(-playerMovementSpeed, playerRigidbody.velocity.y);
            else
            {
                if (playerMovementX == 1)
                    playerRigidbody.velocity = new Vector2(playerMovementSpeed, playerRigidbody.velocity.y);
                else
                    playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platforms") && !isPlayerOnGround)
            isPlayerOnGround = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isPlayerOnGround = false;
    }
}
