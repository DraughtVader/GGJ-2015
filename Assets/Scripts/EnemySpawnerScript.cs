using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject RangedEnemy, MeleeEnemy;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("SpawnCo");
	}
	
    void Spawn()
    {
        if (Random.Range(0,3) == 0)
        {
            Instantiate(RangedEnemy, (Random.insideUnitCircle * 800) + (Vector2)this.transform.position, this.transform.rotation);
            return;
        }
        Instantiate(MeleeEnemy, (Random.insideUnitCircle * 800) + (Vector2)this.transform.position, this.transform.rotation);
    }

	IEnumerator SpawnCo()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(1);
        }
    }
}
