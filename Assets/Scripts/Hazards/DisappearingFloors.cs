using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloors : MonoBehaviour
{
	private int floorIndex = 0;
	private float currTime = 0;
	private static System.Random rando = new System.Random();

	[SerializeField] private List<GameObject> _floors;
	[SerializeField] private float _changeTime = 0.5f;

	// Start is called before the first frame update
	void Start()
	{
		_floors[floorIndex].SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (currTime > _changeTime)
		{
			_floors[floorIndex].SetActive(true);
			floorIndex++;
			currTime = 0;

			if (floorIndex == _floors.Count)
			{
				floorIndex = 0;
			}

			_floors[floorIndex].SetActive(false);
		}

		currTime += Time.deltaTime;
	}
}

/*
random disappearing

_floors[floorIndex].SetActive(true);
			floorIndex = rando.Next(_floors.Count);
			currTime = 0;
			_floors[floorIndex].SetActive(false);


sequential disappearing

{
		if (currTime > _changeTime)
		{
			_floors[floorIndex].SetActive(true);
			floorIndex++;
			currTime = 0;

			if (floorIndex == _floors.Count)
			{
				floorIndex = 0;
			}

			_floors[floorIndex].SetActive(false);
		}

		currTime += Time.deltaTime;
	}

*/
