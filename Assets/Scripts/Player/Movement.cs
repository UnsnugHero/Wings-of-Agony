using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed = 5f;
	public float jumpSpeed = 3f;
	public float spinSpeed = 1f;
	public bool isGrounded;

	public LayerMask groundLayerMask;

	private Rigidbody2D _player;
	private BoxCollider2D _playerCollider;

	// Start is called before the first frame update
	void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_playerCollider = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		isGrounded = IsGrounded();
		HandleJump();
	}

	void FixedUpdate()
	{
		HandleMove();
	}

	void HandleMove()
	{
		float direction = Input.GetAxis("Horizontal");

		if (GetComponent<Death>().isDead)
		{
			direction = 0;
		}

		_player.velocity = new Vector2(direction * speed, _player.velocity.y);
	}

	void HandleJump()
	{
		if (Input.GetKeyDown("space") && isGrounded && !GetComponent<Death>().isDead && !PauseMenu.isPaused)
		{
			_player.velocity = new Vector2(_player.velocity.x, jumpSpeed);
			AudioManager.Instance.PlaySound("Jump");
		}
	}

	bool IsGrounded()
	{
		float extra = 0.1f;
		RaycastHit2D raycastHit = Physics2D.BoxCast(_playerCollider.bounds.center, _playerCollider.bounds.size, 0f, Vector2.down, extra, groundLayerMask);
		return raycastHit.collider != null;
	}
}
