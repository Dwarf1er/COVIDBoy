using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cleanPlatform;
    public GameObject infectedPlatform;
    public GameObject infectedEnemy;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameOverMenu gameOverMenu;
    private PlayerController playerController;
    private int platformDelayCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(platformDelayCounter == 3600)
        {
            InstantiatePlatform();
            InstantiateEnemy();
            platformDelayCounter = 0;
        }

        if (playerController.playerScore <= -20)
        {
            gameOverMenu.ActivateGameOverMenu();
        }

        platformDelayCounter++;

    }

    private void InstantiatePlatform()
    {
        int platformType = Random.Range(0, 2);

        if(platformType == 0)
            Instantiate(cleanPlatform, new Vector3(2250, Random.Range(40, 65) * 10, 0), Quaternion.identity);
        else
            Instantiate(infectedPlatform, new Vector3(2250, Random.Range(40, 65) * 10, 0), Quaternion.identity);
    }

    private void InstantiateEnemy()
    {
        int randomSpawnPoint = Random.Range(0, 4);

        if (randomSpawnPoint == 0)
            Instantiate(infectedEnemy, spawnPoint1.GetComponent<Transform>().position, Quaternion.identity);
        else if (randomSpawnPoint == 1)
            Instantiate(infectedEnemy, spawnPoint2.GetComponent<Transform>().position, Quaternion.identity);
        else if (randomSpawnPoint == 2)
            Instantiate(infectedEnemy, spawnPoint3.GetComponent<Transform>().position, Quaternion.identity);
        else
            Instantiate(infectedEnemy, spawnPoint4.GetComponent<Transform>().position, Quaternion.identity);
    }
}
