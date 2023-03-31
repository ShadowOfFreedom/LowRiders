using UnityEngine;

namespace _Code.CarLogic{
    public class Wheel : MonoBehaviour{
        [SerializeField] bool isSteer;
        [SerializeField] bool isPower;

        [SerializeField] WheelCollider wheelCollider;
        [SerializeField] Transform wheelTransform;

        public float SteerAngle { get; set; }
        public float Acceleration { get; set; }
        public float speed;


        void Update(){
            wheelCollider.GetWorldPose(out var pos, out var rot);
            wheelTransform.position = pos;
            wheelTransform.rotation = rot;
            speed = 2f * 3.14f * wheelCollider.radius * wheelCollider.rpm * 60f;
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