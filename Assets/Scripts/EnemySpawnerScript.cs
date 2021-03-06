﻿using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject MeleeEnemy;

    public float difficulty = 0, incDiff = 0.001f;
    public float MaxNumber = 50;

    public static int TotalNumber;

	// Use this for initialization
	void Start () 
    {
        TotalNumber = 0;
        StartCoroutine("SpawnCo");
	}
	
    void Spawn()
    {
        if (TotalNumber > MaxNumber)
            return;

        Instantiate(MeleeEnemy, (getRandomNormalizedVector() * 600) + (Vector2)this.transform.position, this.transform.rotation);
        
		if(Random.Range(0.0f, 100.0f) < 20.0f)
			this.gameObject.GetComponent<AudioSource>().audio.Play();

		if (difficulty < 0.999f)
            difficulty += incDiff;
        TotalNumber++;
    }

	IEnumerator SpawnCo()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(1f - difficulty);
        }
    }

    Vector2 getRandomNormalizedVector()
    {
        Vector2 v = new Vector2(Random.Range(-1f, 1f),Random.Range(-1f, 1f));
        return v.normalized;
    }
}
