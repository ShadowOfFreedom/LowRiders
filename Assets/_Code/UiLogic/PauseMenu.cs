using _Code.TrackLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.UiLogic{
    public class PauseMenu : MonoBehaviour{
        [SerializeField] Button resumeButton;
        [SerializeField] Button resetButton;
        [SerializeField] Button backToMenuButton;
        [SerializeField] TrackManager trackManager;

        void OnEnable(){
            resumeButton.onClick.AddListener(ResumeGame);
            resetButton.onClick.AddListener(ResetGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
        }

        void OnDisable(){
            resumeButton.onClick.RemoveListener(ResumeGame);
            resetButton.onClick.RemoveListener(ResetGame);
            backToMenuButton.onClick.RemoveListener(BackToMenu);
        }

        void ResumeGame(){
            GameManager.Instance.EnablePlayerInput();
            gameObject.SetActive(false);
        }

        void ResetGame(){
            trackManager.ResetGame();
            gameObject.SetActive(false);
        }

        void BackToMenu() => GameManager.Instance.LoadMenu();
    }
}
