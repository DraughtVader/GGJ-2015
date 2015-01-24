using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;

	private bool _player1Ready = false;
	private bool _player2Ready = false;

	// Use this for initialization
	void Start () 
	{
		Player1.GetComponent<SpriteRenderer>().enabled = false;
		Player2.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetAxisRaw("Action1") > 0)
		{
			_player1Ready = true;
			Player1.GetComponent<SpriteRenderer>().enabled = true;
		}
		if(Input.GetAxisRaw("Action2") >0)
		{
			_player2Ready = true;
			Player2.GetComponent<SpriteRenderer>().enabled = true;
		}
		if(_player1Ready && _player2Ready)
			StartCoroutine(LoadLevelPause());
	}

	IEnumerator LoadLevelPause()
	{
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel(1);
	}
}
