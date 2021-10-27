using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public GameObject cleanEnemy;

    private Rigidbody2D enemyRigidbody { get; set; }
    private Vector2 direction = Vector2.right;
    private static float enemyMovementSpeed = 375f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyMovementSpeed++;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", enemyRigidbody.velocity.x);

        enemyRigidbody.velocity = direction * enemyMovementSpeed;
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (Random.Range(0.0f, 1.0f) < 0.0005f) 
            direction *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.EndsWith("Boundary"))
            Destroy(gameObject);
    }

    public bool Disinfect()
    {
        if(gameObject.tag != "CleanEnemy")
        {
            Instantiate(cleanEnemy, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
