using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public float FinalDistance;

	private float _startPosition;
	private float _currentPosition;
	private float _currentDistance;

	// Use this for initialization
	void Start () 
	{
		_startPosition = (Player1.transform.position.y + Player2.transform.position.y) * 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_currentPosition = (Player1.transform.position.y + Player2.transform.position.y) * 0.5f;
		_currentDistance = _currentPosition - _startPosition;
		//Debug.Log(_currentDistance);

		GameObject.Find("DistanceCounter").GetComponent<Text>().text = "Distance: " + _currentDistance;

		if(Player1 == null && Player2 == null)
			FinalDistance = _currentDistance;
	}
}
