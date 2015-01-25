using UnityEngine;
using System.Collections;

public class GunMovement : MonoBehaviour
{
    public float FrictionForce = 10f;
    [HideInInspector]
    public Vector3 Velocity;

    public bool Held = true;

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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<CharacterMovement>().HasGun = coll.gameObject.GetComponent<CharacterMovement>().IsSnapped = true;
			audio.Play();
            Held = true;
        }
    }
}
