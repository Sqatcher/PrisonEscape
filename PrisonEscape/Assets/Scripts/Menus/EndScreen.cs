using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
	public GameObject timer;
	public Text timeText;

	private void Start()
	{
		Cursor.visible = true;

		float gameTime;
		int min;
		int sec;
		int fraction;

		gameTime = timer.GetComponent<Timer>().GetTime();
		timer.GetComponent<Timer>().CountTime(false);

		min = (int)(gameTime / 60f);
		sec = (int)(gameTime % 60f);
		fraction = (int)((gameTime * 10) % 10);
		timeText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, fraction);

	}
	public void Return()
	{
		//Debug.Log("Return");
		SceneManager.LoadScene(1);
	}
}
