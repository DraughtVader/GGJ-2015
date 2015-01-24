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
	void Start () 
    {
        _player1Transform = GameObject.Find("Player1").transform;
        _player2Transform = GameObject.Find("Player2").transform;
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_isStunned)
            return;

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
        var angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        rigidbody2D.MoveRotation(angle);
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
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            _anim.Play("Idle");
            _isAttacking = false;
            _playerID = "";
        }
    }

    public void AttackPlayer()
    {
        if (_playerID == "")
            return;
        GameObject.Find(_playerID + "Health").GetComponent<Text>().text = _playerID + ": " + (GameObject.Find(_playerID).GetComponent<PlayerStats>().Health -= 20);
    }

    public void Stun()
    {
        StartCoroutine(Stunned());
    }

    IEnumerator Stunned()
    {
        _isStunned = true;
        _anim.Play("EnemyStunned");
        this.rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        _isStunned = false;
        _anim.Play("Idle");
    }
}
