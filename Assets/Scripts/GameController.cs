using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cleanPlatform;
    public GameObject infectedPlatform;
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
            platformDelayCounter = 0;
        }

        platformDelayCounter++;

        if (playerController.playerScore <= -20)
        {
            gameOverMenu.ActivateGameOverMenu();
        }

    }

    private void InstantiatePlatform()
    {
        int platformType = Random.Range(0, 2);

        if(platformType == 0)
            Instantiate(cleanPlatform, new Vector3(2250, Random.Range(40, 65) * 10, 0), Quaternion.identity);
        else
            Instantiate(infectedPlatform, new Vector3(2250, Random.Range(40, 65) * 10, 0), Quaternion.identity);
    }
}
