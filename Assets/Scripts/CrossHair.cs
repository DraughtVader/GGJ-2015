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
        //this.transform.position = transform.parent.position + _aimSight.AimDirection.normalized * 50;

        var angle = Mathf.Atan2(_aimSight.AimDirection.y, _aimSight.AimDirection.x) * Mathf.Rad2Deg;
        GameObject.Find("Gun").transform.localEulerAngles = new Vector3(0,0, angle);

    }
}
