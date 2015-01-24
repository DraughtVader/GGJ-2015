using UnityEngine;
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

    void Start()
    {
        _gun = GameObject.Find("Gun");
    }

    void Update()
    {
        Throw();

        if(!IsSnapped)
			this.rigidbody2D.velocity = Input.GetAxis(XAxis) * Speed * Vector2.right + Input.GetAxis(YAxis) * Speed * Vector2.up;
		if(IsSnapped)
			this.rigidbody2D.velocity = new Vector2(0.0f, 0.0f);

        if (WithGun)
            _gun.transform.position = this.transform.position;
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
            _aiming = false;
            WithGun = false;
        }
    }

    IEnumerator AimThrow()
    {
        float totalTime = 1.3f;
        float t = 0f;
        _throwForce = 0f;

        while (true)
        {
            if (t > totalTime)
                t = 0;

            _throwForce = Mathf.Lerp(0, MaxThrowForce, t / totalTime);
            this.GetComponentInChildren<AimSight>().AimForce = _throwForce;
            t += Time.deltaTime;
            yield return null;
        }
    }

    void Catch()
    {

    }

}
