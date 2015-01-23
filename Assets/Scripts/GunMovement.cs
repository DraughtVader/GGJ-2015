using UnityEngine;
using System.Collections;

public class GunMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Velocity;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position += Velocity * Time.deltaTime;
    }
}
