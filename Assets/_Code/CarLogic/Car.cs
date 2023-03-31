using _Code;
using _Code.CarLogic;
using _Code.UiLogic;
using Unity.Mathematics;
using UnityEngine;

public class Car : MonoBehaviour{
    GameManager gameManager;
    PlayerInput input;

    [SerializeField] Wheel[] wheels;
    [SerializeField] Transform centerOfMass;
    [SerializeField] float motorTorque = 1500f;
    [SerializeField] float maxAngle = 20f;
    [SerializeField] Rigidbody rb;
    [SerializeField] AudioSource audio;

    public HudController hud;

    void Awake(){
        gameManager = GameManager.Instance;
        input = gameManager.Input;
        gameManager.EnablePlayerInput();
        rb.centerOfMass = centerOfMass.localPosition;
    }

    void Update(){
        var moveInput = input.Player.Drive.ReadValue<Vector2>();
        var acceleration = moveInput.y;
        var steering = moveInput.x;

        foreach (var wheel in wheels) {
            wheel.SteerAngle = steering * maxAngle;
            wheel.Acceleration = acceleration * motorTorque;
        }

        var speed = rb.velocity.magnitude * 3.6f;
        var pitch = math.remap(0f, 100f, 0.8f, 1.3f, speed);
        audio.pitch = pitch;
        hud.UpdateSpeedText(rb.velocity.magnitude * 3.6f);
    }

    public void ResetCarMovement(){
        foreach (var wheel in wheels)
            wheel.Stop();
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
}
