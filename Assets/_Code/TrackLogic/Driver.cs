using System;
using System.Collections;
using _Code.UiLogic;
using UnityEngine;

namespace _Code.TrackLogic{
    public class Driver : MonoBehaviour{
        float bestLapTime = Mathf.Infinity;
        float lastLapTime;
        float currentLapTime;
        int currentLap;
        int maxLaps;

        float bestTrackTime; 
        float lastTrackTime;
        float currentTrackTime;

        public HudController hud;

        float lapTimer;
        float trackTimer;
        public Checkpoint[] checkpoints;
        int checkpointIndex;

        int checkpointLayer = 8;

        Checkpoint _last;
        Checkpoint lastCheckpoint {
            get => _last;
            set {
                if (value.isStartStop && _last != null)
                    StartFinish();
                _last = value;
            }
        }

        Checkpoint _next;
        Checkpoint nextCheckpoint {
            get => _next;
            set {
                _next?.Hide();
                _next = value;
                _next.Show();
            }
        }

        public void Init(int max){
            maxLaps = max;
            nextCheckpoint = checkpoints[checkpointIndex];
        }

        public void StartRace(){
            trackTimer = Time.time;
            StartLap();
        }

        void Update(){
            currentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;
            currentTrackTime = trackTimer > 0 ? Time.time - trackTimer : 0;
            hud.UpdateTimers(currentLapTime, currentTrackTime);
        }

        void StartLap(){
            currentLap++;
            hud.UpdateLapIndicator(currentLap);
            lapTimer = Time.time;
        }

        void EndLap(){
            lastLapTime = Time.time - lapTimer;
            bestLapTime = Mathf.Min(lastLapTime, bestLapTime);
            hud.UpdateBestAndLastTime(bestLapTime,lastLapTime);
        }

        bool ContinueRace(){
            if (currentLap != maxLaps)
                return true;
            FinishRace();
            return false;
        }

        void FinishRace(){
            hud.ShowWinMessage(currentTrackTime);
            lapTimer = 0;
            trackTimer = 0;
            GameManager.Instance.DisablePlayerInput();
        }

        void OnTriggerExit(Collider other){
            if (other.gameObject.layer != checkpointLayer)
                return;

            if (other.gameObject == nextCheckpoint.gameObject) {
                hud.HideMissedCheckpointMessage();
                lastCheckpoint = other.GetComponent<Checkpoint>();
                checkpointIndex = checkpoints.Length - 1 == checkpointIndex ? 0 : checkpointIndex + 1;
                Debug.Log(checkpointIndex);
                nextCheckpoint = checkpoints[checkpointIndex];
            }
            else if (other.gameObject != lastCheckpoint?.gameObject) {
                hud.ShowMissedCheckpointMessage();
            }
        }

        void StartFinish(){
            EndLap();
            if (ContinueRace())
                StartLap();
        }
    }
}