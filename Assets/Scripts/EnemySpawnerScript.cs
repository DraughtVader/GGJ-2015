using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject MeleeEnemy;

    public float difficulty = 0, incDiff = 0.001f;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("SpawnCo");
	}
	
    void Spawn()
    {
        Instantiate(MeleeEnemy, (getRandomNormalizedVector() * 600) + (Vector2)this.transform.position, this.transform.rotation);
        if (difficulty < 0.999f)
            difficulty += incDiff;
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
