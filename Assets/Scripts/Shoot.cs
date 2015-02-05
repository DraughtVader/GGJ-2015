using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public string Fire;
	public float ShootDelay;
	public GameObject Bullet;
	public float AmmoCount = 0.0f;
    public bool IsShooting = false;

	private Vector3 _shootDirection;
	private bool _canShoot = true;

	
	// Update is called once per frame
	void Update () 
	{
        if ((Input.GetAxisRaw(Fire) > 0) && (this.GetComponentInParent<CharacterMovement>().IsSnapped) && (this.GetComponentInParent<CharacterMovement>().HasGun) && _canShoot)
        {
            ShootBullet();
			IsShooting = true;
			_canShoot = false;
            StartCoroutine(FireDelay(ShootDelay));
        }
        else
		{   
			IsShooting = false;
		}

	}

	public void ShootBullet ()
	{
		_shootDirection = GetComponentInParent<AimSight>().AimDirection;
		var bullet = Instantiate(Bullet, GetComponentInParent<Transform>().position, Quaternion.identity) as GameObject;
		bullet.GetComponent<BulletMovement>().Direction = _shootDirection;


        var angle = Mathf.Atan2(_shootDirection.y, _shootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.Rotate(new Vector3(0, 0, angle));
        GameObject.Find("Bullet Sound").audio.Play();
        GameObject.Find("Gun").GetComponent<Animator>().Play("Shoot");

        if (_shootDirection.x < 0)
        {
            bullet.transform.localScale = new Vector3(1, -1, 1);
        }
	}

	IEnumerator FireDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		_canShoot = true;
	}
	
}
