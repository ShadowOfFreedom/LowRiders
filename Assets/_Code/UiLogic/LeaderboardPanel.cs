using _Code.Leaderboard;
using TMPro;
using UnityEngine;

namespace _Code.UiLogic{
    public class LeaderboardPanel : MonoBehaviour{
        [SerializeField] GameObject recordTamplate;
        [SerializeField] GameObject easyList;
        [SerializeField] GameObject mediumList;
        [SerializeField] GameObject hardList;

        void OnEnable(){
            for (var i = 1; i <= GameManager.Instance.leaderboard.track1Scores.Count; i++) {
                var score = GameManager.Instance.leaderboard.track1Scores[i-1];
                var record = Instantiate(recordTamplate, easyList.transform);
                var text = record.GetComponent<TMP_Text>();
                text.text = $"{i}. {score.Time:F4} {score.Car} {score.Player}";
            }

            for (var i = 1; i <= GameManager.Instance.leaderboard.track2Scores.Count; i++) {
                var score = GameManager.Instance.leaderboard.track1Scores[i-1];
                var record = Instantiate(recordTamplate, mediumList.transform);
                var text = record.GetComponent<TMP_Text>();
                text.text = $"{i}. {score.Time:F4} {score.Car} {score.Player}";
            }

            for (var i = 1; i <= GameManager.Instance.leaderboard.track3Scores.Count; i++) {
                var score = GameManager.Instance.leaderboard.track1Scores[i-1];
                var record = Instantiate(recordTamplate, hardList.transform);
                var text = record.GetComponent<TMP_Text>();
                text.text = $"{i}. {score.Time:F4} {score.Car} {score.Player}";
            }
        }
    }
}