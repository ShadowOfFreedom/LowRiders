using UnityEngine;

namespace _Code{
    public class Player : MonoBehaviour{
        Car _car;

        public GameObject selectedCar {
            get => _car.gameObject;
            set => _car = value.GetComponent<Car>();
        }
        [SerializeField] public string selectedTrack;

        static Player _instance;
        public static Player Instance => _instance;
        void Awake(){
            if (_instance == null)
                _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}