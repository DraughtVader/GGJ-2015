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
    private SpriteRenderer _indicator;

    void Start()
    {
        _indicator = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Velocity.magnitude > 0f)
        {
            Velocity += -FrictionForce * Velocity.normalized;
            this.transform.position += Velocity * Time.deltaTime;
        }

        _indicator.enabled = !Held;

        if (!Held)
        {
            if (_lastPlayer == "Player1")
            {
                _indicator.color = Color.green;
            }
            else
            {
                _indicator.color = Color.red;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (coll.name == _lastPlayer)
                return;
            coll.gameObject.GetComponent<CharacterMovement>().HasGun = coll.gameObject.GetComponent<CharacterMovement>().IsSnapped = true;
			this.gameObject.GetComponent<AudioSource>().audio.Play();
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
