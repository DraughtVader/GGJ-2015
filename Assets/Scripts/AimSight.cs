using UnityEngine;
using System.Collections;

public class AimSight : MonoBehaviour
{
    public string LookX, LookY;
    public Vector3 AimDirection;
    public float AimForce;

    private Transform _playerTransform;
    private LineRenderer _line;
    
    void Start()
    {
        
        _line = GetComponent<LineRenderer>();
        _playerTransform = GetComponentInParent<Transform>();
    }

    void Update()
    {
        Aim();
    }

    void Aim()
    {
        var tempDir = Input.GetAxis(LookX) * Vector2.right + Input.GetAxis(LookY) * Vector2.up;

        if (tempDir.magnitude > 0.1f)
            AimDirection = tempDir;

        _line.SetPosition(0, _playerTransform.position);
        _line.SetPosition(1, _playerTransform.position + AimDirection.normalized * AimForce * 0.5f);
    }
}
