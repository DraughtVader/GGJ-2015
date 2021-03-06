﻿using UnityEngine;
using System.Collections;

public class SnapPlayer : MonoBehaviour {

	public bool PlayerIsSnapped; //Used for Turret Shoot to check if a player is currently snapped
	private bool _buttonPressed = false; //Used to prevent player from rapid snap/unsnap
	public Collider2D SnappedPlayer;
	public float turretAmmo;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerStay2D(Collider2D player)
	{
		if(player.tag == "Player")
		{
			if((player.GetComponent<CharacterMovement>().HasGun) && (player.GetComponent<CharacterMovement>().IsSnapped == false) && (Input.GetAxisRaw(player.GetComponent<CharacterMovement>().ActionAxis) > 0) && !_buttonPressed)
			{
				Vector3 gunStandPos = this.GetComponentInParent<Transform>().position;
				SnappedPlayer = player;
				player.transform.position = gunStandPos;
				player.GetComponent<CharacterMovement>().IsSnapped = true;
				player.gameObject.GetComponentInChildren<Shoot>().AmmoCount = turretAmmo;
				_buttonPressed = true;
				StartCoroutine(SnapPause());
			}

			if((player.GetComponent<CharacterMovement>().IsSnapped) && (Input.GetAxisRaw(player.GetComponent<CharacterMovement>().ActionAxis) > 0) && !_buttonPressed)
			{
				player.GetComponent<CharacterMovement>().IsSnapped = false;
				turretAmmo = player.gameObject.GetComponentInChildren<Shoot>().AmmoCount;
				player.gameObject.GetComponentInChildren<Shoot>().AmmoCount = 0.0f;
				SnappedPlayer = null;
				_buttonPressed = true;
				StartCoroutine(SnapPause ());
			}
		}
	}

	IEnumerator SnapPause()
	{
		yield return new WaitForSeconds(1.0f);
		_buttonPressed = false;
	}
}
