using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FieldManager : MonoBehaviour
{
    List<Transform> _fields;
    public int[] FieldMarkingsNumbers;
    GameObject[] _fieldMarkings;

    void Start()
    {
        GameObject[] fieldObjs = GameObject.FindGameObjectsWithTag("Field");
        FieldMarkingsNumbers = new int[2];
        _fields = new List<Transform>();
        _fieldMarkings = new GameObject[3];

        foreach (var f in fieldObjs)
        {
            _fields.Add(f.transform);
        }

        _fields = _fields.OrderBy(x => x.transform.position.y).ToList();
        for (int i = 0; i < 2; i++)
        {
            FieldMarkingsNumbers[i] = (i + 1) * 10 * (_fields.IndexOf(this.transform)+1);
            _fieldMarkings[i] = transform.GetChild(2).transform.GetChild(i).gameObject;
            _fieldMarkings[i].transform.GetChild(0).GetComponent<Text>().text = ""+FieldMarkingsNumbers[i];
            _fieldMarkings[i].transform.GetChild(1).GetComponent<Text>().text = ""+FieldMarkingsNumbers[i];
        }
    }

    void Update()
    {
        Vector3 top = this.transform.position + 384 * Vector3.up;
        Vector3 cameraBottom = Camera.main.transform.position + 864 * Vector3.down;
        Vector3 topMostField = Vector3.zero;

        foreach (var f in _fields)
        {
            if (f.position.y > topMostField.y)
            {
                topMostField = f.position;
            }
        }

        if (top.y < cameraBottom.y)
        {
            this.transform.position = topMostField + 768 * Vector3.up;

            _fields = _fields.OrderBy(x => x.transform.position.y).ToList();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    FieldMarkingsNumbers[i] = _fields[1].GetComponent<FieldManager>().FieldMarkingsNumbers[1] + 10;
                else
                    FieldMarkingsNumbers[i] = _fields[1].GetComponent<FieldManager>().FieldMarkingsNumbers[1] + 20;

                _fieldMarkings[i] = transform.GetChild(2).transform.GetChild(i).gameObject;
                _fieldMarkings[i].transform.GetChild(0).GetComponent<Text>().text = "" + FieldMarkingsNumbers[i];
                _fieldMarkings[i].transform.GetChild(1).GetComponent<Text>().text = "" + FieldMarkingsNumbers[i];
            }
        }
    }
}
