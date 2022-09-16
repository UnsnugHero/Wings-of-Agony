using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MovingObject
{
	private bool _hasActivated = false;
	private Animator _gunShotAnimator;


	[SerializeField] private Vector2 _shootPlayerAngle;
	[SerializeField] private float _shootPlayerForce = 2500f;
	[SerializeField] private float _torque;

	private void Start()
	{
		GameObject gunshot = GameObject.Find("Gun Shot");
		_gunShotAnimator = gunshot.GetComponent<Animator>();
	}

	private void Update()
	{
		if (transform.position.Equals(_activeSpot) && !_hasActivated)
		{
			_hasActivated = true;
			HandleShootPlayer();
		}
	}

	public override void Reset()
	{
		base.Reset();
		_hasActivated = false;
		_gunShotAnimator.SetBool("shouldShoot", false);
	}

	private void HandleShootPlayer()
	{
		AudioManager.Instance.PlaySound("Shot");
		GameObject player = GameObject.Find("Player");
		Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
		_gunShotAnimator.SetBool("shouldShoot", true);

		StartCoroutine(player.GetComponent<Death>().KillPlayer(1f));
		playerRB.AddForce(_shootPlayerAngle * _shootPlayerForce);
		playerRB.AddTorque(_torque);
	}
}
