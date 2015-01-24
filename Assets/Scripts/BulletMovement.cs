using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float BulletSpeed;
	public float BulletLife;

	[HideInInspector]
	public Vector3 Direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position += Direction * BulletSpeed * Time.deltaTime;
		BulletLife -= Time.deltaTime;

		if(BulletLife <= 0.0f)
			GameObject.Destroy(this.gameObject);
		//Debug.Log(Direction);
	}
}
