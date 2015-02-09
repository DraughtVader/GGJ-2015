using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour 
{
	public bool IsShaking;
	public int XOffset;
	public int YOffset;
	private Vector3 _offsetVector;
	private Vector3 _shakeStartPosition;


	void Start()
	{
		IsShaking = false;
	}

	void Update()
	{
		if(IsShaking)
		{
			_shakeStartPosition = gameObject.transform.position;
			_offsetVector = new Vector3(Random.Range(-XOffset, XOffset), Random.Range(-YOffset, YOffset), 0.0f);
			gameObject.transform.position = _shakeStartPosition + _offsetVector;
		}
	}

}
