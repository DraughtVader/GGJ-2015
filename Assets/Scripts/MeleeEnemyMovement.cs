using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeleeEnemyMovement : MonoBehaviour {

    private Transform _player1Transform, _player2Transform;
    private bool _isAttacking;
    private Animator _anim;
    private string _playerID = "";
    private bool _isStunned;

    public float Speed = 10;
    public bool Dead;
	public AudioClip attackGrunt;

	void Start () 
    {
        _player1Transform = GameObject.Find("Player1").transform;
        _player2Transform = GameObject.Find("Player2").transform;
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Dead)
            return;

        rigidbody2D.isKinematic = false;
        if (_isAttacking)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else
            GoAfterPlayer(ClosestPlayer());
	}

    void GoAfterPlayer(Vector3 position)
    {
        rigidbody2D.velocity = (position - this.transform.position).normalized * Speed;

        if (rigidbody2D.velocity.y > 0)
        {
            _anim.Play("EnemyBack");
        }
        else
        {
            _anim.Play("EnemyFront");
        }
    }

    Vector3 ClosestPlayer()
    {
        if (Vector3.Distance(_player1Transform.position, this.transform.position) > (Vector3.Distance(_player2Transform.position, this.transform.position)))
            return _player2Transform.position;
        else
            return _player1Transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            _anim.Play("EnemyAttacking");
            _isAttacking = true;
            _playerID = coll.gameObject.name;
			this.GetComponent<AudioSource>().clip = attackGrunt;
			audio.PlayOneShot(attackGrunt, 1.0f);

            if (rigidbody2D.velocity.y < 0)
                transform.localScale = new Vector3(1, -1, 1) * 2;
            else
                transform.localScale = Vector3.one * 2;
            
        }
       
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            _anim.Play("Idle");
            _isAttacking = false;
            _playerID = "";
            transform.localScale = Vector3.one * 2;
        }
    }

    public void AttackPlayer()
    {
        if (_playerID == "")
            return;
        GameObject.Find(_playerID + "Health").GetComponent<Text>().text = _playerID + ": " + (GameObject.Find(_playerID).GetComponent<PlayerStats>().Health -= 20);
    }

    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void EndGame()
    {
        GameObject.Find("GameOverText").GetComponent<Animator>().SetTrigger("GameOver");
        GameObject.Find("DistanceRecord").GetComponent<Text>().text = 
            GameObject.Find("DistanceRecordShadow").GetComponent<Text>().text = "Distance: " + DistanceTracker.CurrentDistance;
        //Time.timeScale = 0;
        GameObject.Find("GameOverText").GetComponent<Text>().text = "GAME OVER";
        Game.GameOver = true;
    }
}
