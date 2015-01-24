using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyProjectileScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameObject.Find(coll.name + "Health").GetComponent<Text>().text = coll.name + ": " + (coll.GetComponent<PlayerStats>().Health -= 50);
            GameObject.Destroy(this.gameObject);
        }
    }
}
