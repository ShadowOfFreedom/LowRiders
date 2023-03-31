using _Code.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace _Code{
    public class GameManager : MonoBehaviour{
        const string MainScn = "scn_main";

        static GameManager _instance;
        public static GameManager Instance => _instance;

        public PlayerInput Input;
        DefaultInputActions _uiInput;

        [SerializeField] Cars cars;
        [SerializeField] Tracks tracks;

        void Awake(){
            if (_instance == null)
                _instance = this;
            Input ??= new PlayerInput();
            _uiInput ??= new DefaultInputActions();
            DontDestroyOnLoad(this);
        }

        public void EnablePlayerInput() => Input.Player.Enable();

        public void DisablePlayerInput() => Input.Player.Disable();

        public void StartNewGame(int carIndex, int trackIndex){
            Player.Instance.selectedCar = cars.carsDictionary[carIndex];
            Player.Instance.selectedTrack = tracks.tracksDictionary[trackIndex];

            SceneManager.LoadScene(Player.Instance.selectedTrack, LoadSceneMode.Single);
        }

        public void LoadMenu()
            => SceneManager.LoadScene(MainScn, LoadSceneMode.Single);
    }
}
