using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Code.TrackLogic{
    public class Driver : MonoBehaviour{
        [Header("Lap times")]
        [SerializeField] float bestLapTime = Mathf.Infinity;
        [SerializeField] float lastLapTime;
        [SerializeField] float currentLapTime;
        [SerializeField] int currentLap;

        [Header("Track time")]
        [SerializeField] float bestTrackTime;
        [SerializeField] float lastTrackTime;
        [SerializeField] float currentTrackTime;

        // [SerializeField] public TMP_Text timeLabel;

        float lapTimer;
        float trackTimer;
        public Checkpoint[] checkpoints;
        int checkpointIndex;

        Checkpoint _last;
        Checkpoint lastCheckpoint {
            get => _last;
            set {
                if (value.isStartStop)
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

        int checkpointLayer = 8;

        public void Init(){
            nextCheckpoint = checkpoints[checkpointIndex];
            lastCheckpoint = checkpoints[checkpointIndex];
        }

        void Update(){
            currentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;
            // timeLabel.text = $"{currentLapTime:F3} sec";
        }

        void StartLap(){
            currentLap++;
            lapTimer = Time.time;
        }

        void EndLap(){
            lastLapTime = Time.time - lapTimer;
            bestLapTime = Mathf.Min(lastLapTime, bestLapTime);
            Debug.Log($"last lap time: {lastLapTime:F4}");
            Debug.Log($" best lap time: {bestLapTime:F4}");
        }

        void OnTriggerEnter(Collider other){
            if (other.gameObject.layer != checkpointLayer)
                return;

            if (other.gameObject == nextCheckpoint.gameObject) {
                lastCheckpoint = other.GetComponent<Checkpoint>();
                checkpointIndex = checkpoints.Length - 1 == checkpointIndex ? 0 : checkpointIndex + 1;
                nextCheckpoint = checkpoints[checkpointIndex];
            }
            else if (other.gameObject != lastCheckpoint.gameObject) {
                // Debug.Log("you mise checkpoint");
            }
        }

        void StartFinish(){
            Debug.Log("startFinish");
            EndLap();
            StartLap();
        }
    }
}