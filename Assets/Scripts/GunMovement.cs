using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunMovement : MonoBehaviour
{
    public float FrictionForce = 10f;
    [HideInInspector]
    public Vector3 Velocity;

    public bool Held = true;
    private string _lastPlayer = "Player1";

    void Start()
    {

    }

    void Update()
    {
        if (Velocity.magnitude > 0f)
        {
            Velocity += -FrictionForce * Velocity.normalized;
            this.transform.position += Velocity * Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.name == _lastPlayer)
                return;
            coll.gameObject.GetComponent<CharacterMovement>().HasGun = coll.gameObject.GetComponent<CharacterMovement>().IsSnapped = true;
            Held = true;
            _lastPlayer = coll.name;
        }
        else if (coll.gameObject.tag == "SideBounds") 
        {
            Time.timeScale = 0;
            GameObject.Find("GameOverText").GetComponent<Text>().text = "GAME OVER";
            Game.GameOver = true;
        }
    }
}
