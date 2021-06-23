using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI bestLapTime;
    public Button pauseButton;

    void Start()
    {
         //pauseButton.onClick.AddListener(delegate { GamePlayManager.Instance.PlayPause(); });
    }

    void Update()
    {
        
    }

    public void UpdateBestLapTime(float lapTime)
    {
        bestLapTime.text = "Best Time: " + lapTime;
    }
}
