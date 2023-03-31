using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Code.Leaderboard{
    public class LeaderboardManager{
        // static LeaderboardManager _instance;
        // public static LeaderboardManager Instance => _instance == null ? new LeaderboardManager() : _instance;
        const int lastIndex = 9;
        const string track1Key = "track1Scores";
        const string track2Key = "track2Scores";
        const string track3Key = "track3Scores";

        public List<LeaderboardData> track1Scores = new();
        public List<LeaderboardData> track2Scores = new();
        public List<LeaderboardData> track3Scores = new();

        public LeaderboardManager(){
            string json;
            if (PlayerPrefs.HasKey(track1Key)) {
                json = PlayerPrefs.GetString(track1Key);
                track1Scores = JsonUtility.FromJson<List<LeaderboardData>>(json);
            } else if (PlayerPrefs.HasKey(track2Key)) {
                json = PlayerPrefs.GetString(track2Key);
                track2Scores = JsonUtility.FromJson<List<LeaderboardData>>(json);
            } else if (PlayerPrefs.HasKey(track3Key)) {
                json = PlayerPrefs.GetString(track3Key);
                track3Scores = JsonUtility.FromJson<List<LeaderboardData>>(json);
            }
        }

        public void AddScore(LeaderboardData score){
            switch (score.Track) {
                case 0:
                    track1Scores.Add(score);
                    track1Scores.OrderBy(s => s.Time);
                    if (track1Scores.Count > lastIndex)
                        track1Scores.RemoveRange(lastIndex, track1Scores.Count - lastIndex);
                    break;
                case 1:
                    track2Scores.Add(score);
                    track2Scores.OrderBy(s => s.Time);
                    if (track2Scores.Count > lastIndex)
                        track2Scores.RemoveRange(lastIndex, track2Scores.Count - lastIndex);
                    break;
                case 2:
                    track3Scores.Add(score);
                    track3Scores.OrderBy(s => s.Time);
                    if (track3Scores.Count > lastIndex)
                        track3Scores.RemoveRange(lastIndex, track3Scores.Count - lastIndex);
                    break;
            }
            Save();
        }

        public void Save(){
            var json = JsonUtility.ToJson(track1Scores);
            PlayerPrefs.SetString(track1Key, json);
            json = JsonUtility.ToJson(track2Scores);
            PlayerPrefs.SetString(track2Key, json);
            json = JsonUtility.ToJson(track3Scores);
            PlayerPrefs.SetString(track3Key, json);
            PlayerPrefs.Save();
        }
    }
}