using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	public float timeValue = 0;
	public float maxTime = 3600;
	public bool isCounting = true;
	public TMP_Text timerText;

	// Update is called once per frame
	void Update()
	{
		if (isCounting)
		{
			timeValue += Time.deltaTime;
			if (timeValue > maxTime)
			{
				timeValue = maxTime;
			}
		}

		DisplayTime();
	}

	private void DisplayTime()
	{
		if (timeValue == maxTime)
		{
			timerText.text = "Yer Slow";
		}

		float minutes = Mathf.FloorToInt(timeValue / 60);
		float seconds = Mathf.FloorToInt(timeValue % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
