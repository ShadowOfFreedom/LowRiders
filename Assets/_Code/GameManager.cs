using _Code.Data;
using _Code.Leaderboard;
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

        public int trackIndex;
        public LeaderboardManager leaderboard;
        void Awake(){
            if (_instance == null)
                Init();
        }

        void Init(){
            _instance = this;
            Input ??= new PlayerInput();
            _uiInput ??= new DefaultInputActions();
            leaderboard = new LeaderboardManager();
            DontDestroyOnLoad(this);
        }

        public void EnablePlayerInput() => Input.Player.Enable();

        public void DisablePlayerInput() => Input.Player.Disable();

        public void StartNewGame(int carIndex, int trackIndex){
            this.trackIndex = trackIndex;
            Player.Instance.selectedCar = cars.carsDictionary[carIndex];
            Player.Instance.selectedTrack = tracks.tracksDictionary[trackIndex];

            SceneManager.LoadScene(Player.Instance.selectedTrack, LoadSceneMode.Single);
        }

        public void LoadMenu()
            => SceneManager.LoadScene(MainScn, LoadSceneMode.Single);
    }
}
