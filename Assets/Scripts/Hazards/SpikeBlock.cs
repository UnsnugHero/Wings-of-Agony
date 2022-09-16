using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlock : MonoBehaviour
{
	private Vector3 _startPosition;

	[SerializeField] private float _frequency = 5f;
	[SerializeField] private float _magnitude = 5f;
	[SerializeField] private Vector3 _direction;

	// Start is called before the first frame update
	void Start()
	{
		_startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = _startPosition + _direction * Mathf.Sin(Time.time * _frequency) * _magnitude;
	}
}
