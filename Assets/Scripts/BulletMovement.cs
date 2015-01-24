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
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.rigidbody2D.velocity = Vector2.zero;
            coll.GetComponent<MeleeEnemyMovement>().Dead = true;
            coll.GetComponent<Animator>().Play("EnemyDead");
        }
    }
}
