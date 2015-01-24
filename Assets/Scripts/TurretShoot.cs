using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {

	public GameObject Bullet;
	private Collider2D _player;
	public Vector3 ShootDirection;
	private string _lookingX;
	private string _lookingY;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		_player = this.GetComponent<SnapPlayer>().SnappedPlayer;

		if(this.GetComponent<SnapPlayer>().PlayerIsSnapped)
		{
			_lookingX = _player.gameObject.GetComponentInChildren<AimSight>().LookX;
			_lookingY = _player.gameObject.GetComponentInChildren<AimSight>().LookY;
			ShootDirection = _player.gameObject.GetComponentInChildren<AimSight>().AimDirection;

		}
	}

	void Shoot()
	{

	}
}
