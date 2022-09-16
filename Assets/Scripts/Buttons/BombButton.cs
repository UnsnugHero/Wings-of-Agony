using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : Button
{
	[SerializeField] private int _triggerNumber;

	protected override void HandleButtonPress()
	{
		SetButtonPressed();
		Explosions explosions = GameObject.Find("Explosions").GetComponent<Explosions>();
		KillPlayer();
		StartCoroutine(TriggerExplosions(explosions));
	}

	private void KillPlayer()
	{
		GameObject player = GameObject.Find("Player");
		player.GetComponentInChildren<SpriteRenderer>().enabled = false;
		StartCoroutine(player.GetComponent<Death>().KillPlayer(1f));
	}

	private IEnumerator TriggerExplosions(Explosions explosions)
	{
		for (int i = 0; i < _triggerNumber; i++)
		{
			// AudioManager.Instance.
			StartCoroutine(explosions.TriggerExplosions());
			yield return null;
		}
	}
}
