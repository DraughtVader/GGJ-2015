using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	public Vector2 Amplitude;
	public Vector2 Frequency;
	public AnimationCurve Decay;
	public float ShakeTime;
	public bool CanShake;

    public GameObject Player1;
    public GameObject Player2;

	private Vector3 originalPos;

	void Start()
	{
		originalPos = transform.position;
       Player1 = GameObject.Find("Player1").gameObject;
       Player2 = GameObject.Find("Player2").gameObject;
	}

	void Update()
	{
		if((Player1.GetComponentInChildren<Shoot>().IsShooting) || (Player2.GetComponentInChildren<Shoot>().IsShooting))
		{
			//originalPos = transform.position;
			Shake();
			//StartCoroutine(ShakeWait());
		}
	}

	void Shake()
	{
		transform.position += new Vector3(Mathf.Cos(Time.time * Frequency.x) * Amplitude.x, 
		                                  Mathf.Sin(Time.time * Frequency.y) * Amplitude.y, 0);
        Debug.Log("Shaking");
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
