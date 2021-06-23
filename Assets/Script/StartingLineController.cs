using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLineController : MonoBehaviour
{  
    [HideInInspector]public bool lapRoute;
    [HideInInspector]public float counterTimeLap;

    private void Update()
    {
        if (lapRoute)
        {
           counterTimeLap += Time.deltaTime;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
          lapRoute = true;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            lapRoute = false;
            GamePlayManager.Instance.m_stopwatch = counterTimeLap;
            counterTimeLap = 0f;

        }
    }

}
