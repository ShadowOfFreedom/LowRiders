using System.Collections.Generic;
using _Code;
using Cinemachine;
using UnityEngine;

public class TrackManager : MonoBehaviour{
    [SerializeField] Transform playerStartPosition;
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] List<Checkpoint> checkpoints;

    void Awake(){
        var car = Player.Instance.selectedCar;
        var carGO = Instantiate(car, playerStartPosition.position, playerStartPosition.rotation);
        camera.LookAt = carGO.transform;
        camera.Follow = carGO.transform;
    }
}
