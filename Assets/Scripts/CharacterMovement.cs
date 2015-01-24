using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public float Speed, MaxThrowForce, SlowSpeed;
    public string XAxis, YAxis, ThrowAxis, ActionAxis;
    public bool HasGun = false;
    public bool IsSnapped = false;

    public Vector3 AimDirection { get { return GetComponentInChildren<AimSight>().AimDirection; } }

    private bool _aiming;
    private GameObject _gun;
    private float _throwForce;
    public Animator Anim;
    public SpriteRenderer Sprite;

    void Start()
    {
        _gun = GameObject.Find("Gun");
        Anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Throw();

        if(!IsSnapped)
        {
			this.rigidbody2D.velocity = Input.GetAxis(XAxis) * Speed * Vector2.right + Input.GetAxis(YAxis) * Speed * Vector2.up;
            if (HasGun)
            {
                this.rigidbody2D.velocity *= 0.1f;
            }
        }

        if (HasGun)
			_gun.transform.position = this.transform.position;

		if(IsSnapped)
        {
            return;
        }

        this.transform.localScale = CalcScale();
    }

    private Vector3 CalcScale()
    {
        var scale = this.transform.localScale;

        if (rigidbody2D.velocity.y > 0)
        {
            Anim.Play("WalkBack");
        }
        else
        {
            Anim.Play("WalkFront");
        }

        return scale;
    }

    public void Throw()
    {
        if (Input.GetAxis(ThrowAxis) > 0 && HasGun && !_aiming)
        {
            StartCoroutine("AimThrow");
            _aiming = true;
        }

        if (Input.GetAxis(ThrowAxis) == 0 && HasGun && _aiming)
        {
            StopCoroutine("AimThrow");
            _gun.GetComponent<GunMovement>().Velocity = AimDirection * _throwForce;
            IsSnapped = false;
            this.GetComponentInChildren<AimSight>().AimForce = 0f;
            _aiming = false;
            HasGun = false;
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
