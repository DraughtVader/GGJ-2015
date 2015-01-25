﻿using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float BulletSpeed;
	[HideInInspector]
	public Vector3 Direction;
	// Use this for initialization
	void Start () {
        StartCoroutine("TTL");
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
            EnemySpawnerScript.TotalNumber--;
        }
    }

    IEnumerator TTL()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(this.gameObject);
    }
}
