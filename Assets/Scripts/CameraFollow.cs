using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform _gun;
	void Start () 
    {
        _gun = GameObject.Find("Gun").transform;	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = new Vector3(this.transform.position.x, _gun.position.y + 150, -10);
	}
}
