using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
	public bool active = false;

	[SerializeField] protected Vector2 _initialSpot;
	[SerializeField] protected Vector2 _activeSpot;
	[SerializeField] protected float _moveSpeed = 5f;

	void FixedUpdate()
	{
		if (active)
		{
			transform.position = Vector2.MoveTowards(transform.position, _activeSpot, _moveSpeed);
		}
	}

	public virtual void Reset()
	{
		transform.position = _initialSpot;
		active = false;
	}
}
