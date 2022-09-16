using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	public bool isDead = false;

	private Rigidbody2D _rigidBody;
	private BoxCollider2D _boxCollider2D;
	private GameObject _camera;

	[SerializeField] private float _afterDeathDelay = 0.75f;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_boxCollider2D = GetComponent<BoxCollider2D>();

		_camera = GameObject.Find("Main Camera");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Pain") && !isDead)
		{
			HandleDeathSound(other.tag);

			if (other.tag == "Crush Trigger")
			{
				StartCoroutine(KillPlayer(1f));
			}
			else
			{
				StartCoroutine(KillPlayer(_afterDeathDelay));
			}
		}
	}

	public IEnumerator KillPlayer(float waitTime)
	{
		_camera.GetComponent<CameraFollow>().SetFollowing(false);
		_boxCollider2D.enabled = false;
		_rigidBody.constraints = RigidbodyConstraints2D.None;
		isDead = true;

		yield return new WaitForSeconds(waitTime);
		GetComponent<Respawn>().RespawnPlayer();
	}

	private void HandleDeathSound(string tag)
	{
		if (tag == "Crush Trigger")
		{
			AudioManager.Instance.PlaySound("Crush");
			AudioManager.Instance.PlaySound("Crush_Yell");
		}
		else if (tag == "Fall Trigger")
		{
			AudioManager.Instance.PlaySound("Fall");
		}
		else
		{
			// there's absolutely a better way to do this, but im close to my deadline :(
			System.Random rng = new System.Random();
			int randomInt = rng.Next(1, 102);

			if (randomInt <= 20)
			{
				AudioManager.Instance.PlaySound("Spike_Scream");
			}
			else if (randomInt <= 40)
			{
				AudioManager.Instance.PlaySound("Spike_Scream_2");
			}
			else if (randomInt <= 60)
			{
				AudioManager.Instance.PlaySound("Spike_Scream_3");

			}
			else if (randomInt <= 80)
			{
				AudioManager.Instance.PlaySound("Spike_Scream_4");

			}
			else if (randomInt <= 100)
			{
				AudioManager.Instance.PlaySound("Spike_Scream_5");
			}
			else
			{
				AudioManager.Instance.PlaySound("Spike_Scream_6");
			}
		}
	}
}
