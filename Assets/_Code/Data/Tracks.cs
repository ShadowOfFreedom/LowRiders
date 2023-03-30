using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _Code.CarLogic{
    [CreateAssetMenu(fileName = "Tracks", menuName = "ScriptableObjects/Tracks", order = 1)]
    public class Tracks : ScriptableObject{
        [SerializeField] public List<SceneAsset> tracksDictionary;
    }
}