using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private Button restartButton { get; set; }
    private Button mainMenuButton { get; set; }

    private void Start()
    {
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        mainMenuButton = GameObject.Find("MainMenuButton").GetComponent<Button>();

        restartButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
    }

    public void ActivateGameOverMenu()
    {
        gameObject.SetActive(true);
    }
}
