using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public string Fire;
	public float ShootDelay;
	public GameObject Bullet;

	private Vector3 _shootDirection;
	private bool _canShoot = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if((Input.GetAxisRaw(Fire) > 0) && (this.GetComponentInParent<CharacterMovement>().IsSnapped) &&_canShoot)
		{
			ShootBullet();
			_canShoot = false;
			StartCoroutine(FireDelay(ShootDelay));
		}
	}

	public void ShootBullet ()
	{
		_shootDirection = GetComponentInParent<AimSight>().AimDirection;
		Debug.Log (_shootDirection);
		Instantiate(Bullet, GetComponentInParent<Transform>().position, Quaternion.identity);
		Bullet.GetComponent<BulletMovement>().Direction = _shootDirection;
	}

	IEnumerator FireDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		_canShoot = true;
	}
}
