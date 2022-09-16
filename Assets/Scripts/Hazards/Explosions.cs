using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
	[SerializeField] private float _timeBetweenExplosions;

	public IEnumerator TriggerExplosions()
	{
		foreach (Transform child in transform)
		{
			AudioManager.Instance.PlaySound("Explode");
			Animator childAnimator = child.GetComponent<Animator>();
			childAnimator.SetTrigger("explode");
			yield return new WaitForSeconds(_timeBetweenExplosions);
		}
	}
}
