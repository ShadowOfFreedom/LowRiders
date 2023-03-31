using System.Collections.Generic;
using UnityEngine;

namespace _Code.Data{
    [CreateAssetMenu(fileName = "Tracks", menuName = "ScriptableObjects/Tracks", order = 1)]
    public class Tracks : ScriptableObject{
        [SerializeField] public List<string> tracksDictionary;
    }
}