using UnityEngine;
using System.Collections;

public class GunMovement : MonoBehaviour
{
    public float FrictionForce = 10f;
    [HideInInspector]
    public Vector3 Velocity;

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
}
