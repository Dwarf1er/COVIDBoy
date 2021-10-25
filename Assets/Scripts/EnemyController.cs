using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator infectedAnimator;
    public Animator cleanAnimator;

    private Rigidbody2D enemyRigidbody { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        infectedAnimator.SetFloat("Horizontal", enemyRigidbody.velocity.x);
        cleanAnimator.SetFloat("Horizontal", enemyRigidbody.velocity.x);

        enemyRigidbody.velocity = (transform.right * new Vector2(1, 0)).normalized * 800;
    }
}
