using _Code;
using _Code.CarLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    static GameManager instance;
    public static GameManager Instance => instance;

    public PlayerInput input;
    DefaultInputActions uiInput;

    [SerializeField] Cars cars;
    [SerializeField] Tracks tracks;

    void Awake(){
        if (instance == null)
            instance = this;
        input ??= new PlayerInput();
        uiInput ??= new DefaultInputActions();
        DontDestroyOnLoad(this);
    }

    public void InitInput(){
        input.Player.Enable();
    }

    public void StartNewGame(int carIndex, int trackIndex){
        Player.Instance.selectedCar = cars.carsDictionary[carIndex];
        var selectedTrack = tracks.tracksDictionary[trackIndex];

        SceneManager.LoadScene(selectedTrack.name, LoadSceneMode.Single);
    }
}
