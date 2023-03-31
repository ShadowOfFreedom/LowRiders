using System.Collections.Generic;
using _Code;
using _Code.TrackLogic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrackManager : MonoBehaviour{
    [SerializeField] Transform playerStartPosition;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Checkpoint[] checkpoints;

    [SerializeField] GameObject pauseMenu;

    PlayerInput input;
    GameObject playerCar;
    Car car;
    Driver driver;

    void Awake(){
        Time.timeScale = 1;
        playerCar = Instantiate(Player.Instance.selectedCar, playerStartPosition.position, playerStartPosition.rotation);
        car = playerCar.GetComponent<Car>();
        driver = playerCar.GetComponent<Driver>();
        driver.checkpoints = checkpoints;
        driver.Init();
        virtualCamera.LookAt = playerCar.transform;
        virtualCamera.Follow = playerCar.transform;

        input = GameManager.Instance.Input;
        input.Player.Pause.started += ShowPauseMenu;
    }

    void ShowPauseMenu(InputAction.CallbackContext obj){
        if (pauseMenu == null) {
            Debug.Log("pause menu is null");
            return;
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.DisablePlayerInput();
    }

    public void ResetGame(){
        car.ResetCarMovement();
        Time.timeScale = 1;
        playerCar.transform.transform.position = playerStartPosition.position;
        playerCar.transform.transform.rotation = playerStartPosition.rotation;
        GameManager.Instance.EnablePlayerInput();
    }
}
