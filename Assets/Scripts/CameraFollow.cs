using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform _gun;
	private Vector3 _midpoint;
	private float _playerDistance;

	//Max camera size is 288
	//Min camera size should be 150/175

	public GameObject Player1;
	public GameObject Player2;
	public float CameraMinSize;
	public float CameraMaxSize;

	void Start () 
    {
        _gun = GameObject.Find("Gun").transform;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        
		_midpoint = (Player1.transform.position + Player2.transform.position) * 0.5f;
		_playerDistance = Vector3.Distance(Player1.transform.position, Player2.transform.position) * 0.5f;

		if(_playerDistance >= CameraMinSize && _playerDistance <= CameraMaxSize)
		gameObject.GetComponent<Camera>().orthographicSize = _playerDistance;

		this.transform.position = new Vector3(_midpoint.x, _midpoint.y, -10.0f);
	}
}
