using UnityEngine;
using System.Collections;

public class SnapPlayer : MonoBehaviour {

	public bool PlayerIsSnapped; //Used for Turret Shoot to check if a player is currently snapped
	private bool _buttonPressed = false; //Used to prevent player from rapid snap/unsnap
	public GameObject SnappedPlayer;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerStay2D(Collider2D player)
	{
		Debug.Log(Input.GetAxisRaw("Action1"));
		if(player.tag == "Player")
		{
            if ((player.GetComponent<CharacterMovement>().WithGun) && (player.GetComponent<CharacterMovement>().IsSnapped == false) && (Input.GetAxisRaw(player.GetComponent<CharacterMovement>().ActionAxis) > 0) && !_buttonPressed)
			{
				Vector3 gunStandPos = this.GetComponentInParent<Transform>().position;
				SnappedPlayer = player.gameObject;
				player.transform.position = gunStandPos;
				player.GetComponent<CharacterMovement>().IsSnapped = true;
				_buttonPressed = true;
				StartCoroutine(SnapPause());
			}

            if ((player.GetComponent<CharacterMovement>().IsSnapped) && (Input.GetAxisRaw(player.GetComponent<CharacterMovement>().ActionAxis) > 0) && !_buttonPressed)
			{
				player.GetComponent<CharacterMovement>().IsSnapped = false;
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
