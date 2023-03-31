using UnityEngine;

namespace _Code.CarLogic{
    public class Wheel : MonoBehaviour{
        [SerializeField] bool isSteer;
        [SerializeField] bool isPower;

        [SerializeField] WheelCollider wheelCollider;
        [SerializeField] Transform wheelTransform;

        public float SteerAngle { get; set; }
        public float Acceleration { get; set; }

        void Update(){
            wheelCollider.GetWorldPose(out var pos, out var rot);
            wheelTransform.position = pos;
            wheelTransform.rotation = rot;
        }

        void FixedUpdate(){
            if (isSteer)
                wheelCollider.steerAngle = SteerAngle;

            if (isPower)
                wheelCollider.motorTorque = Acceleration;
        }

        public void Stop(){
            wheelCollider.motorTorque = 0;
            wheelCollider.steerAngle = 0;
            wheelCollider.rotationSpeed = 0;
        }
    }
}