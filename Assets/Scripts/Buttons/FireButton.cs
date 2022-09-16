using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : Button
{
	protected override void HandleButtonPress()
	{
		SetButtonPressed();
		GameObject.Find("Fires").GetComponent<Fires>().SetFiresActive(true);
		HandleBurnPlayer();
	}

	private void HandleBurnPlayer()
	{
		GameObject player = GameObject.Find("Player");
		StartCoroutine(player.GetComponent<Death>().KillPlayer(1f));
	}
}
