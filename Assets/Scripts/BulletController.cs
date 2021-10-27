using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float maskSpeed = 2500f;
    private Rigidbody2D maskRigidbody { get; set; }
    private Range range { get; set; }

    private void Start()
    {
        maskRigidbody = gameObject.GetComponent<Rigidbody2D>();
        range = GetComponentInChildren<Range>();
    }

    private void FixedUpdate()
    {
        maskRigidbody.velocity = transform.right * maskSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            List<EnemyController> enemiesToDelete = new List<EnemyController>(range.enemiesInRange);
            int disinfectedCount = 0;
            foreach(EnemyController enemy in enemiesToDelete)
            {
                if (enemy.Disinfect())
                    disinfectedCount++;
            }

            PlayerController.playerScore += disinfectedCount * 2;

            Destroy(gameObject);
        }
    }
}
