using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunButton : Button
{
	protected override void HandleButtonPress()
	{
		SetButtonPressed();
		GameObject.Find("Gun and Shot").GetComponent<Gun>().active = true;
	}
}
