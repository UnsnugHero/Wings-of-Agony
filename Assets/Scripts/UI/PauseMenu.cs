using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;

	private GameObject _pauseMenu;

	private void Start()
	{
		_pauseMenu = GameObject.Find("PauseMenu");
		_pauseMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				OnPlay();
			}
			else
			{
				OnPause();
			}
		}
	}

	public void OnPause()
	{
		_pauseMenu.SetActive(true);
		AudioManager.Instance.PauseAudio();
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void OnPlay()
	{
		_pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
		AudioManager.Instance.ResumeAudio();
	}

	public void OnQuit()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
		isPaused = false;
		AudioManager.Instance.StopAllAudio();
	}
}
