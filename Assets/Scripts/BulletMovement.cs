using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float BulletSpeed;
	[HideInInspector]
	public Vector3 Direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position += Direction * BulletSpeed * Time.deltaTime;
		//Debug.Log(Direction);
	}
}
