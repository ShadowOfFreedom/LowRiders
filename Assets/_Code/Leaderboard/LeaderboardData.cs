using System;

namespace _Code.Leaderboard{
    [Serializable]
    public struct LeaderboardData{
        public int Track;
        public float Time;
        public string Car;
        public string Player;
    }
}