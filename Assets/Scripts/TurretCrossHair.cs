using UnityEngine;
using System.Collections;

public class TurretCrossHair : MonoBehaviour {

	private TurretShoot _turretAimSight;
	private Transform _characterTransform;
	// Use this for initialization
	void Start () 
	{
		_characterTransform = GetComponentInParent<Transform>();
		_turretAimSight = transform.parent.GetComponentInChildren<TurretShoot>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = transform.parent.position + _turretAimSight.ShootDirection.normalized * 40;
	}
}
