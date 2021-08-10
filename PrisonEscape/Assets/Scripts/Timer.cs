using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;

    static float startTime = 0f;
    static bool countTime = true;
    float gameTime;
    int min;
    int sec;
    int fraction;

    // Start is called before the first frame update
    void Start()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
        }

        if (countTime)
        {
            gameTime = Time.time - startTime;
            min = (int)(gameTime / 60f);
            sec = (int)(gameTime % 60f);
            fraction = (int)((gameTime * 10) % 10);
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, fraction);
        }
    }

    public void CountTime(bool isTrue)
    {
        countTime = isTrue;
    }

    public float GetTime()
    {
        return Time.time - startTime;
    }

    public void ResetTime()
	{
        startTime = 0f;
	}
}
