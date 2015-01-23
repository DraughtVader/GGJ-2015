using UnityEngine;
using System.Collections;

public class SnapPlayer : MonoBehaviour {

	// Use this for initialization
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
			if((player.GetComponent<CharacterMovement>().HasGun) && (player.GetComponent<CharacterMovement>().IsSnapped == false) && (Input.GetAxisRaw(player.GetComponent<CharacterMovement>().ActionAxis) > 0))
			{
				Vector3 gunStandPos = this.GetComponentInParent<Transform>().position;
				player.transform.position = gunStandPos;
				player.GetComponent<CharacterMovement>().IsSnapped = true;
			}
		}
	}
}
