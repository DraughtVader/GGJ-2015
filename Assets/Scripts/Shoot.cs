﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public string Fire;
	public float ShootDelay;
	public GameObject Bullet;
	public float AmmoCount = 0.0f;

	private Vector3 _shootDirection;
	private bool _canShoot = true;
	// Use this for initialization
	void Start () 
	{
//		GameObject.Find("AmmoCounter").GetComponent<Text>().text = "Turret Ammo: " + AmmoCount;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		if((Input.GetAxisRaw(Fire) > 0) && (this.GetComponentInParent<CharacterMovement>().IsSnapped) && (this.GetComponentInParent<CharacterMovement>().WithGun) && _canShoot)
		{
			ShootBullet();
			_canShoot = false;
			StartCoroutine(FireDelay(ShootDelay));
            GameObject.Find("Gun").GetComponent<Animator>().Play("Shoot");
		}
        else
        {
         //   GameObject.Find("Gun").GetComponent<Animator>().Play("Idle");
        }
	}

	public void ShootBullet ()
	{
		_shootDirection = GetComponentInParent<AimSight>().AimDirection;
		Instantiate(Bullet, GetComponentInParent<Transform>().position, Quaternion.identity);
		Bullet.GetComponent<BulletMovement>().Direction = _shootDirection;
		AmmoCount -= 1.0f;
//		GameObject.Find("AmmoCounter").GetComponent<Text>().text = "Turret Ammo: " + AmmoCount;
	}

	IEnumerator FireDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		_canShoot = true;
	}
}
