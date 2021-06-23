using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton<GamePlayManager>
{
    private float m_Stopwatch = 0f;

    public HUDController m_HUD;
    public GameSettingsDatabase settingsDatabase;

    public float Stopwatch
    {
        get { return m_Stopwatch; }
        set
        {
           
            if(settingsDatabase.lastBestLapTime != 0)
            {
                float score = m_Stopwatch - settingsDatabase.lastBestLapTime;
                if (score < 0)
                {
                    m_Stopwatch = value;
                    m_HUD.UpdateBestLapTime(m_Stopwatch);
                    settingsDatabase.lastBestLapTime = m_Stopwatch;
                }
            }
            else 
            {
                m_Stopwatch = value;
                m_HUD.UpdateBestLapTime(m_Stopwatch);
                settingsDatabase.lastBestLapTime = m_Stopwatch;
              
            }
        }
    }
   void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(m_HUD);
    }
}
