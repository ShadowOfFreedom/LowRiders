using Cinemachine;
using UnityEngine;

namespace _Code{
    public class Player : MonoBehaviour{
        [SerializeField] public GameObject selectedCar;

        static Player instance;
        public static Player Instance => instance;
        void Awake(){
            if (instance == null)
                instance = this;
            DontDestroyOnLoad(this);
        }
    }
}