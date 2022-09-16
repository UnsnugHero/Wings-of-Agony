using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get { return _instance; }
	}

	public float finishTime = 0;

	private int _sacredDeaths = 0;
	private GameObject _fadeImage;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
	}

	private void Start()
	{
		_fadeImage = GameObject.Find("FadeToBlack");
		_fadeImage.SetActive(false);
		AudioManager.Instance.PlaySound("Gameplay_Music");
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			if (this.gameObject)
			{
				Destroy(this.gameObject);
				_instance = null;
			}
		}
	}

	public void ResetState()
	{
		Destroy(this.gameObject);
		_instance = null;
	}

	public void IncrementSacredDeaths()
	{
		_sacredDeaths++;

		if (_sacredDeaths == 5)
		{
			Time.timeScale = 0.8f;
			Timer timer = GameObject.Find("Time").GetComponent<Timer>();
			finishTime = timer.timeValue;
			timer.isCounting = false;

			StartCoroutine(EndGame());
		}
	}

	public IEnumerator EndGame()
	{
		_fadeImage.SetActive(true);
		FadeToBlack fade = _fadeImage.GetComponent<FadeToBlack>();
		yield return StartCoroutine(fade.FadeScreenToBlack());
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
