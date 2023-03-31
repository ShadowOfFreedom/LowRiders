using UnityEngine;

namespace _Code.TrackLogic{
    public class Checkpoint : MonoBehaviour{
        [SerializeField] BoxCollider checkpointCollider;
        [SerializeField] MeshRenderer mesh;
        public bool isStartStop;

        public void Show(){
            if (mesh != null)
                mesh.enabled = true;
        }

        public void Hide(){
            if (mesh != null)
                mesh.enabled = false;
        }
    }
}
