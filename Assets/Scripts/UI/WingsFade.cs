using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WingsFade : MonoBehaviour
{
	private Image _image;

	[SerializeField] private float _fadeSpeed = 1f;
	[SerializeField] private float _fadeDelay = 1f;

	// Start is called before the first frame update
	void Start()
	{
		_image = GetComponent<Image>();
		StartCoroutine(FadeIn());
	}

	private IEnumerator FadeIn()
	{
		while (_image.color.a < 1)
		{
			Color imageColor = _image.color;
			float fadeAmount = imageColor.a + (_fadeSpeed * Time.deltaTime);

			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, fadeAmount);
			yield return null;
		}
		yield return new WaitForSeconds(_fadeDelay);
		StartCoroutine(FadeOut());
	}

	private IEnumerator FadeOut()
	{
		while (_image.color.a > 0)
		{
			Color imageColor = _image.color;
			float fadeAmount = imageColor.a - (_fadeSpeed * Time.deltaTime);

			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, fadeAmount);
			yield return null;
		}
		yield return new WaitForSeconds(_fadeDelay);
		StartCoroutine(FadeIn());
	}
}
