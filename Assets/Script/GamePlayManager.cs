using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton<GamePlayManager>
{
    public float m_stopwatch = 0f;

    public HUDController m_HUD;
    public GameSettingsDatabase settingsDatabase;

   void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(m_HUD);
    }

    private void Update()
    {
        if (settingsDatabase.lastBestLapTime != 0)
        {
            float score = m_stopwatch - settingsDatabase.lastBestLapTime;
            if(score < 0)
            {
                m_HUD.UpdateBestLapTime(m_stopwatch);
                settingsDatabase.lastBestLapTime = m_stopwatch;
            }
        }
        else
        {
            m_HUD.UpdateBestLapTime(m_stopwatch);
            settingsDatabase.lastBestLapTime = m_stopwatch;
        }
    }
}
