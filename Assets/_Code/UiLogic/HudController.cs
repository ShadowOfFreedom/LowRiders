using System.Collections;
using _Code.TrackLogic;
using TMPro;
using UnityEngine;

namespace _Code.UiLogic{
    public class HudController : MonoBehaviour{
        [Header("Lap Time")]
        [SerializeField] TMP_Text lapTime;
        [SerializeField] TMP_Text lastLapTime;
        [SerializeField] TMP_Text bestLapTime;
        [SerializeField] TMP_Text lapIndicator;

        [Header("Total Time")]
        [SerializeField] TMP_Text totalTime;

        [Header("Speed")]
        [SerializeField] TMP_Text speed;

        [Header("Messages")]
        [SerializeField] GameObject missedCheckpoint;
        [SerializeField] GameObject win;
        [SerializeField] TMP_Text finalTime;

        [SerializeField] TMP_Text count;

        int totalLaps;
        public Driver driver;

        public void Init(int maxLaps, float bestLap){
            totalLaps = maxLaps;
            lapIndicator.text = $"{1}/{maxLaps}";
            bestLapTime.text = $"{bestLap:F4}";
            StartCoroutine(Count());
        }

        public void ShowMissedCheckpointMessage(){
            if (!missedCheckpoint.activeInHierarchy)
                missedCheckpoint.SetActive(true);
        }

        public void HideMissedCheckpointMessage(){
            if (missedCheckpoint.activeInHierarchy)
                missedCheckpoint.SetActive(false);
        }

        public void ShowWinMessage(float time){
            if (win.activeInHierarchy) return;
            win.SetActive(true);
            finalTime.text = $"Your time: {time:F4}";
        }

        public void HideWinMessage(){
            if (win.activeInHierarchy)
                win.SetActive(false);
        }

        public void UpdateSpeedText(float value){
            speed.text = $"{value:F0} km/h";
        }

        public void UpdateTimers(float lap, float total){
            lapTime.text = $"{lap:F4}";
            totalTime.text = $"{total:F4}";
        }

        public void UpdateLapIndicator(int currentLap){
            lapIndicator.text = $"{currentLap}/{totalLaps}";
        }

        public void UpdateBestAndLastTime(float bestTime, float lastTime){
            bestLapTime.text = $"{bestTime:F4}";
            lastLapTime.text = $"{lastTime:F4}";
        }

        IEnumerator Count(){
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(1);
            count.text = "2";
            yield return new WaitForSecondsRealtime(1);
            count.text = "1";
            yield return new WaitForSecondsRealtime(1);
            count.fontSize = 200;
            count.text = "START!";
            Time.timeScale = 1;
            driver.StartRace();
            yield return new WaitForSecondsRealtime(.5f);
            count.gameObject.SetActive(false);
        }
    }
}
