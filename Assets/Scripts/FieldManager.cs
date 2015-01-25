using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldManager : MonoBehaviour
{
    List<Transform> Fields;

    void Start()
    {
        GameObject[] fieldObjs = GameObject.FindGameObjectsWithTag("Field");
        Fields = new List<Transform>();
        foreach (var f in fieldObjs)
        {
            Fields.Add(f.transform);
        }
    }

    void Update()
    {
        Vector3 top = this.transform.position + 384 * Vector3.up;
        Vector3 cameraBottom = Camera.main.transform.position + 864 * Vector3.down;
        Vector3 topMostField = Vector3.zero;
            
        foreach (var f in Fields)
        {
            if (f.position.y > topMostField.y)
            {
                topMostField = f.position;
            }
        }

        if (top.y < cameraBottom.y)
        {
            this.transform.position = topMostField + 768 * Vector3.up;
        }
    }
}
