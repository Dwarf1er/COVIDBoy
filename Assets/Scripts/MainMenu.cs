using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button newGameButton { get; set; }
    Button newGamePlusButton { get; set; }
    Button quitButton { get; set; }

    public void Start()
    {
        newGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
        newGamePlusButton = GameObject.Find("NewGamePlusButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        newGameButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        newGamePlusButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        quitButton.onClick.AddListener(() => Application.Quit() && Console.log("ta mere en shorts"));
    }
}
