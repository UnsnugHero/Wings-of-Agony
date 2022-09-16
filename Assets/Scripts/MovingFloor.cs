using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
	private Vector2 _initialSpot;
	private Vector2 _currMoveToSpot;
	private float _currTime = 0;

	[SerializeField] private Vector2 _moveSpot;
	[SerializeField] private float _changeTime = 0.5f;
	[SerializeField] private float _moveSpeed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		_initialSpot = transform.position;
		_currMoveToSpot = _moveSpot;
	}

	private void Update()
	{
		_currTime += Time.deltaTime;

		if (_currTime >= _changeTime)
		{
			bool isInStartSpot = transform.position.Equals(_initialSpot);
			_currMoveToSpot = isInStartSpot ? _moveSpot : _initialSpot;
			_currTime = 0;
		}
	}

	void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards(transform.position, _currMoveToSpot, _moveSpeed);
	}
}
