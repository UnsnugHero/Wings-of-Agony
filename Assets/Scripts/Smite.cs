using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : MonoBehaviour
{
	public void SetSmiting(bool smiting)
	{
		Animator smiteAnimator = GetComponent<Animator>();
		smiteAnimator.SetBool("isSmiting", smiting);

		if (smiting)
		{
			AudioManager.Instance.PlaySound("Smite");
		}
		else
		{
			AudioManager.Instance.StopSound("Smite");
		}
	}
}
