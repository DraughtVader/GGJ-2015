using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour
{
    public float Speed;

    void Start()
    {

    }

    void Update()
    {
        //print(this.GetComponent<Material>().mainTextureOffset);
        renderer.material.mainTextureOffset = Speed * Vector3.down;
        //Speed++;
    }
}
