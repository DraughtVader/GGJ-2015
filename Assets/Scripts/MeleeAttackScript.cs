using UnityEngine;
using System.Collections;

public class MeleeAttackScript : MonoBehaviour {

    private Transform _attackPosition;

    public string MeleeAxis;
	// Use this for initialization
	void Start () {
        _attackPosition = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetAxis(MeleeAxis) > 0 )
        {
            Melee();
        }
	}

    void Melee()
    {
        var enemies = Physics2D.OverlapCircleAll(_attackPosition.position, 15, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (var item in enemies)
        {
           // item.transform.position += (item.transform.position-this.transform.position).normalized * 25;
            item.GetComponent<MeleeEnemyMovement>().Stun();
            item.rigidbody2D.AddForce((item.transform.position - this.transform.position).normalized * 100, ForceMode2D.Impulse);
        }
    }
}
