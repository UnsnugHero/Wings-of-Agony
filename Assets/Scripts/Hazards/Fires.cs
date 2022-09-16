using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fires : MonoBehaviour
{
	public void SetFiresActive(bool active)
	{
		if (active)
		{
			AudioManager.Instance.PlaySound("Fire_Ignite");
			AudioManager.Instance.PlaySound("Fire_Scream_2");
		}

		foreach (Transform child in transform)
		{
			SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
			childRenderer.enabled = active;
		}
	}
}
