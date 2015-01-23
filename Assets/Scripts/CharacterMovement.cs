using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public float Speed;
	public string XAxis, YAxis, ThrowAxis, ActionAxis;

    public Vector3 AimDirection { get { return GetComponentInChildren<AimSight>().AimDirection; } }

	public bool HasGun = false;
	public bool IsSnapped = false;
    
	private bool _withGun;
    private GameObject _gun;

    void Start()
    {
        _gun = GameObject.Find("Gun");
        _withGun = true;
    }

    void Update()
    {
        if(!IsSnapped)
			this.rigidbody2D.velocity = Input.GetAxis(XAxis) * Speed * Vector2.right + Input.GetAxis(YAxis) * Speed * Vector2.up;
        
		if (Input.GetAxis(ThrowAxis) > 0)
        {
            if (_withGun)
                Throw();
            else
                Catch();
        }

        if (_withGun)
            _gun.transform.position = this.transform.position;
    }

    public void Throw()
    {
        _gun.GetComponent<GunMovement>().Velocity = AimDirection * 300f;
        _withGun = false;
    }

    void Catch()
    {

    }
    
}
