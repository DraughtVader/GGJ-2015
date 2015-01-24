using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour
{
    private AimSight _aimSight;
    private Transform _characterTransform;

    void Start()
    {
        _characterTransform = GetComponentInParent<Transform>();
        _aimSight = transform.parent.GetComponentInChildren<AimSight>();

    }

    void Update()
    {
        if (transform.parent.GetComponent<CharacterMovement>().HasGun)
        {
            var angle = Mathf.Atan2(_aimSight.AimDirection.y, _aimSight.AimDirection.x) * Mathf.Rad2Deg;
            GameObject.Find("Gun").transform.localEulerAngles = new Vector3(0,0, angle);

            if (angle > 0 && angle < 180)
            {
                transform.parent.GetComponent<CharacterMovement>().Anim.Play("WalkBack");
                transform.parent.GetComponent<CharacterMovement>().Sprite.sortingOrder = 3;
            }
            else
            {
                transform.parent.GetComponent<CharacterMovement>().Anim.Play("WalkFront");
                transform.parent.GetComponent<CharacterMovement>().Sprite.sortingOrder = 0;
            }
        }
    }
}
