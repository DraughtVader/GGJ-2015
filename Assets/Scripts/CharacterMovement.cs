﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public float Speed, MaxThrowForce;
    public string XAxis, YAxis, ThrowAxis, ActionAxis;
    public bool HasGun = false;
    public bool IsSnapped = false;
    public bool WithGun = true;

    public Vector3 AimDirection { get { return GetComponentInChildren<AimSight>().AimDirection; } }

    private bool _aiming;
    private GameObject _gun;
    private float _throwForce;
    private Animator _anim;

    void Start()
    {
        _gun = GameObject.Find("Gun");
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Throw();

        if(!IsSnapped)
        {
			this.rigidbody2D.velocity = Input.GetAxis(XAxis) * Speed * Vector2.right + Input.GetAxis(YAxis) * Speed * Vector2.up;
            if (WithGun)
            {
                this.rigidbody2D.velocity *= 0.1f;
            }
        }

        if (WithGun)
            _gun.transform.position = this.transform.position;

		if(IsSnapped)
        {
			this.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
            _anim.Play("WalkFront");
            return;
        }

        this.transform.localScale = CalcScale();
    }

    private Vector3 CalcScale()
    {
        var scale = this.transform.localScale;
        if (Mathf.Abs(rigidbody2D.velocity.x) >= Mathf.Abs(rigidbody2D.velocity.y))
        {
            if (rigidbody2D.velocity.x > 0)
                scale.x = -Mathf.Abs(this.transform.localScale.x);
            else
                scale.x = Mathf.Abs(this.transform.localScale.x);
            _anim.Play("WalkSide");
        }
        else
        {
            if (rigidbody2D.velocity.y > 0)
                _anim.Play("WalkBack");
            else
                _anim.Play("WalkFront");
        }
        return scale;
    }

    public void Throw()
    {
        if (Input.GetAxis(ThrowAxis) > 0 && WithGun && !_aiming)
        {
            StartCoroutine("AimThrow");
            _aiming = true;
        }

        if (Input.GetAxis(ThrowAxis) == 0 && WithGun && _aiming)
        {
            StopCoroutine("AimThrow");
            _gun.GetComponent<GunMovement>().Velocity = AimDirection * _throwForce;
            IsSnapped = false;
            this.GetComponentInChildren<AimSight>().AimForce = 0f;
            _aiming = false;
            WithGun = false;
        }
    }

    IEnumerator AimThrow()
    {
        float totalTime = 2f;
        float t = 0f;
        _throwForce = 100f;

        while (true)
        {
            if (t > totalTime)
                t = 0;

            _throwForce = Mathf.Lerp(500, MaxThrowForce, t / totalTime);
            this.GetComponentInChildren<AimSight>().AimForce = _throwForce * 0.75f ;
            t += Time.deltaTime;
            yield return null;
        }
    }

    void Catch()
    {

    }

}
