using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject mask;
    public static int playerScore = 0;
    public bool isPlayerFacingRight = true;

    private Rigidbody2D playerRigidbody { get; set; }
    private Transform playerMaskOrigin { get; set; }
    private Vector2 playerVelocity { get; set; }
    private bool isPlayerOnGround { get; set; }
    private Vector2 notMoving { get; set; }

    [SerializeField] private float playerMovementSpeed = 1500f;
    [SerializeField] private float playerFireRate = 0.01f;
    private float timeBeforeNextShot;
    private Vector3 rightShotPosition;
    private Vector3 leftShotPosition;
    private float timeBeforeNextSpeedBoost;
    private float playerBoostCooldown = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        notMoving = Vector2.zero;

        playerVelocity = notMoving;
        isPlayerOnGround = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMaskOrigin = GameObject.Find("maskOrigin").GetComponent<Transform>();
        rightShotPosition = playerMaskOrigin.localPosition;
        leftShotPosition = playerMaskOrigin.localPosition * -1;
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetBool("OnGround", isPlayerOnGround);
        animator.SetBool("FacingRight", isPlayerFacingRight);
        MovePlayer();

        GameObject.Find("ScoreText").GetComponent<Text>().text = playerScore.ToString();
    }

    private void MovePlayer()
    {
        float playerMovementX = Input.GetAxisRaw("Horizontal");

        Vector2 playerHorizontalMovement = transform.right * playerMovementX;
        Vector2 playerFinalVelocity = playerHorizontalMovement.normalized * playerMovementSpeed;
        playerVelocity = playerFinalVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnGround)
            playerRigidbody.AddForce(Vector3.up * 6000, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Mouse0) && timeBeforeNextShot < Time.time)
            ShootPlayer();

        if(Input.GetKeyDown(KeyCode.Q) && GameController.isVariantGameMode && timeBeforeNextSpeedBoost < Time.time)
            StartCoroutine(BoostPlayer());

        if (playerVelocity != notMoving)
        {
            if (playerMovementX == -1)
            {
                playerRigidbody.velocity = new Vector2(-playerMovementSpeed, playerRigidbody.velocity.y);
                isPlayerFacingRight = false;
                playerMaskOrigin.localPosition = leftShotPosition;
            }
            else
            {
                if (playerMovementX == 1)
                {
                    playerRigidbody.velocity = new Vector2(playerMovementSpeed, playerRigidbody.velocity.y);
                    isPlayerFacingRight = true;
                    playerMaskOrigin.localPosition = rightShotPosition;
                }
                else
                    playerRigidbody.velocity = new Vector2(0, playerRigidbody.velocity.y);
            }
        }
    }

    private void ShootPlayer()
    {
        float fireAngle;

        if (isPlayerFacingRight)
            fireAngle = 0;
        else
            fireAngle = 180;

        Instantiate(mask, playerMaskOrigin.position, Quaternion.Euler(0, 0, fireAngle));

        timeBeforeNextShot = Time.time + playerFireRate;
    }

    private IEnumerator BoostPlayer()
    {
        playerMovementSpeed *= 2;
        yield return new WaitForSeconds(3);
        playerMovementSpeed /= 2;
        timeBeforeNextSpeedBoost = Time.time + playerBoostCooldown;
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
