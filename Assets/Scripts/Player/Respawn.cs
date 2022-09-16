using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
	private BoxCollider2D _boxCollider2D;
	private GameObject _camera;
	private Rigidbody2D _rigidBody;
	private SpriteRenderer _spriteRenderer;

	[SerializeField] private Transform _spawnPoint;

	// Start is called before the first frame update
	void Start()
	{
		_boxCollider2D = GetComponent<BoxCollider2D>();
		_rigidBody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		_camera = GameObject.Find("Main Camera");
	}

	public void RespawnPlayer()
	{
		transform.position = _spawnPoint.position;
		transform.localRotation = Quaternion.identity;

		_boxCollider2D.enabled = true;
		_rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		_camera.GetComponent<CameraFollow>().SetFollowing(true);
		_spriteRenderer.enabled = true;

		GetComponent<Death>().isDead = false;
		Reset();
	}

	private void Reset()
	{
		GameObject.Find("Gun and Shot").GetComponent<Gun>().Reset();
		GameObject.Find("Crushing Wall").GetComponent<CrushingWall>().Reset();
		GameObject.Find("Fires").GetComponent<Fires>().SetFiresActive(false);
		GameObject.Find("Smite").GetComponent<Smite>().SetSmiting(false);
	}
}
