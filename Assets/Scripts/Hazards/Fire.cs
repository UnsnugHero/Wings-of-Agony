using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	private Animator _animator;

	[SerializeField] private float _speed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		_animator = GetComponent<Animator>();
		_animator.speed = _speed;
	}
}
