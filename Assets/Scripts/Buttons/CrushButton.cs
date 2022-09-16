using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushButton : Button
{
	protected override void HandleButtonPress()
	{
		SetButtonPressed();
		GameObject.Find("Crushing Wall").GetComponent<CrushingWall>().active = true;
	}
}
