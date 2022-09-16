using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
	private bool _hasBeenPressed = false;
	private bool _isInteractable = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.X) && _isInteractable && !PauseMenu.isPaused)
		{
			HandleButtonPress();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		_isInteractable = true;
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			GameObject.Find("Prompt").GetComponent<MeshRenderer>().enabled = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		_isInteractable = false;
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			GameObject.Find("Prompt").GetComponent<MeshRenderer>().enabled = false;
		}
	}

	protected void SetButtonPressed()
	{
		if (!_hasBeenPressed)
		{
			GameManager.Instance.IncrementSacredDeaths();
			_hasBeenPressed = true;
		}
	}

	protected abstract void HandleButtonPress();
}
