using _Code;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour{
    [Header("Main Menu")]
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] Button newGameButton;
    [SerializeField] Button leaderboardButton;
    [SerializeField] Button exitButton;

    [Header("Leaderboard")]
    [SerializeField] GameObject leaderboardCanvas;
    [SerializeField] Button exitLeaderboardButton;

    [Header("New Game Menu")]
    [SerializeField] GameObject newGameCanvas;
    [SerializeField] TMP_Dropdown carDropdown;
    [SerializeField] TMP_Dropdown trackDropdown;
    [SerializeField] Button startGameButton;
    [SerializeField] Button backButton;

    void OnEnable(){
        newGameButton.onClick.AddListener(ShowNewGameMenu);
        leaderboardButton.onClick.AddListener(ShowLeaderboard);
        exitButton.onClick.AddListener(ExitGame);
    }

    void OnDisable(){
        newGameButton.onClick.RemoveListener(ShowNewGameMenu);
        leaderboardButton.onClick.RemoveListener(ShowLeaderboard);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    void ShowNewGameMenu(){
        mainMenuCanvas.SetActive(false);
        newGameCanvas.SetActive(true);
        carDropdown.Select();
        startGameButton.onClick.AddListener(StartNewGame);
        backButton.onClick.AddListener(BackToMainMenu);
    }

    void StartNewGame(){
        var carIndex = carDropdown.value;
        var trackIndex = trackDropdown.value;
        GameManager.Instance.StartNewGame(carIndex, trackIndex);
    }

    void BackToMainMenu(){
        startGameButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        newGameCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    void ShowLeaderboard(){
        mainMenuCanvas.SetActive(false);
        leaderboardCanvas.SetActive(true);
    }

    void ExitGame(){
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
