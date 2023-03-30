using System.Collections.Generic;
using UnityEngine;

namespace _Code.CarLogic{
    [CreateAssetMenu(fileName = "Cars", menuName = "ScriptableObjects/Cars", order = 0)]
    public class Cars : ScriptableObject{
        [SerializeField] public List<GameObject> carsDictionary;
    }
}