using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	public float rotateSpeed;

	private Animator _animator;
	private Movement _playerMovement;
	private Rigidbody2D _player;
	private SpriteRenderer _spriteRenderer;
	private Death _playerDeath;

	// Start is called before the first frame update
	void Start()
	{
		_animator = GetComponent<Animator>();
		_playerMovement = GetComponentInParent<Movement>();
		_playerDeath = GetComponentInParent<Death>();
		_player = GetComponentInParent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		_animator.SetBool("isDead", _playerDeath.isDead);
		HandleSpriteFlip();
		HandleMovingAnim();
		HandleJumpingAnim();
	}

	void FixedUpdate()
	{
		HandleSpriteSpin();
	}

	private void HandleSpriteFlip()
	{
		float direction = Input.GetAxis("Horizontal");

		if (GetComponentInParent<Death>().isDead)
		{
			direction = 0f;
		}

		if (direction < 0)
		{
			_spriteRenderer.flipX = true;
		}
		else
		{
			_spriteRenderer.flipX = false;
		}
	}

	private void HandleMovingAnim()
	{
		bool isMoving = Mathf.Abs(_player.velocity.x) > 0;
		_animator.SetBool("isMoving", isMoving);
	}

	private void HandleJumpingAnim()
	{
		bool isGrounded = _playerMovement.isGrounded;
		_animator.SetBool("isJumping", !isGrounded);
	}

	private void HandleSpriteSpin()
	{
		if (!GetComponentInParent<Death>().isDead)
		{
			if (_playerMovement.isGrounded)
			{
				transform.rotation = Quaternion.identity;
			}
			else
			{
				float direction = Input.GetAxisRaw("Horizontal");
				float zRotation = transform.rotation.z + rotateSpeed * -direction;
				transform.Rotate(transform.rotation.x, transform.rotation.y, zRotation);
			}
		}
	}
}
