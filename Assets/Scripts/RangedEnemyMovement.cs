using UnityEngine;
using System.Collections;

public class RangedEnemyMovement : MonoBehaviour {

    private Transform _player1Transform, _player2Transform;
    private Animator _anim;
    private Vector2 _closestPlayerPos;
    private float _shotCoolDown = 2;
    private bool _isStunned;

    public float Speed = 10;
    public float Range = 250;
    public GameObject Projectile;
    public float BulletSpeed = 200;
    void Start()
    {
        _player1Transform = GameObject.Find("Player1").transform;
        _player2Transform = GameObject.Find("Player2").transform;
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_isStunned)
            return;

        if (PlayerInRange())
        {
            Shoot();
        }
        else
        {
            GoAfterPlayer();
        }
    }

    void GoAfterPlayer()
    {
        rigidbody2D.velocity = (_closestPlayerPos - (Vector2)this.transform.position).normalized * Speed;
        var angle = Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        rigidbody2D.MoveRotation(angle);
    }

    bool PlayerInRange()
    {
        _closestPlayerPos = ClosestPlayer();
        if (Vector3.Distance(_closestPlayerPos, this.transform.position) < Range)
        {
            return true;
        }
        return false;
    }

    Vector3 ClosestPlayer()
    {
        if (Vector3.Distance(_player1Transform.position, this.transform.position) > (Vector3.Distance(_player2Transform.position, this.transform.position)))
            return _player2Transform.position;
        else
            return _player1Transform.position;
    }

    void Shoot()
    {
        rigidbody2D.velocity = Vector2.zero;
        if (_shotCoolDown < 0)
        {
            var projectile = GameObject.Instantiate(Projectile, this.transform.position, this.transform.rotation) as GameObject;
            projectile.rigidbody2D.velocity = (_closestPlayerPos - (Vector2)this.transform.position).normalized * BulletSpeed;
            var angle = Mathf.Atan2(projectile.rigidbody2D.velocity.y, projectile.rigidbody2D.velocity.x) * Mathf.Rad2Deg;
            rigidbody2D.MoveRotation(angle);
            _shotCoolDown = 2;
            this.transform.localScale = Vector3.one * 5;
        }
        else
        {
            this.transform.localScale += new Vector3(0.02f, 0.02f, 0);
            _shotCoolDown -= Time.deltaTime;
        }
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
