using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	public Vector2 Amplitude;
	public Vector2 Frequency;
	public AnimationCurve Decay;
	public float ShakeTime;
	public bool CanShake;

	private Vector3 originalPos;

	void Start()
	{
		originalPos = transform.position;		
	}

	void Update()
	{
		if(CanShake)
		{
			//originalPos = transform.position;
			Shake();
			StartCoroutine(ShakeWait());
		}
	}

	void Shake()
	{
		transform.position += new Vector3(Mathf.Cos(Time.time * Frequency.x) * Amplitude.x, 
		                                  Mathf.Sin(Time.time * Frequency.y) * Amplitude.y, 0);
	}

	IEnumerator ShakeWait()
	{
		yield return new WaitForSeconds(ShakeTime);
		CanShake = false;
		ResetPosition();
	}

	void ResetPosition()
	{
		transform.position = originalPos;
	}

}
