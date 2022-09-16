using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmiteButton : Button
{
	protected override void HandleButtonPress()
	{
		SetButtonPressed();
		GameObject.Find("Smite").GetComponent<Smite>().SetSmiting(true);
		GameObject player = GameObject.Find("Player");
		StartCoroutine(player.GetComponent<Death>().KillPlayer(1f));
	}
}
