using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
	private GameManager _gameManager;

	private void Start()
	{
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		DisplayTime();
	}

	public void OnQuit()
	{
		SceneManager.LoadScene(0);
		AudioManager.Instance.StopAllAudio();
	}

	public void OnRetry()
	{
		_gameManager.ResetState();
		SceneManager.LoadScene(3);
	}

	public void DisplayTime()
	{
		TMP_Text timerText = GameObject.Find("Win Time").GetComponent<TMP_Text>();
		float timeValue = _gameManager.finishTime;
		float minutes = Mathf.FloorToInt(timeValue / 60);
		float seconds = Mathf.FloorToInt(timeValue % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
