using UnityEngine;
using System.Collections;
using System.Linq;

public class CameraFollow : MonoBehaviour
{

    private Transform _gun;
    private Vector3 _midpoint;
    private float _playerDistance;
    private Transform[] _objects = new Transform[3];

    //Max camera size is 288
    //Min camera size should be 150/175

    public GameObject Player1;
    public GameObject Player2;
    public float CameraMinSize;
    public float CameraMaxSize;

    void Start()
    {
        _gun = GameObject.Find("Gun").transform;
        _objects[0] = _gun;
        _objects[1] = Player1.transform;
        _objects[2] = Player2.transform;

        Method2();

    }

    // Update is called once per frame
    void Update()
    {
        Method2();
    }

    void Method1()
    {
        _midpoint = (Player1.transform.position + Player2.transform.position) * 0.5f;
        _playerDistance = Vector3.Distance(Player1.transform.position, Player2.transform.position) * 0.5f;

        if (_playerDistance >= CameraMinSize && _playerDistance <= CameraMaxSize)
            gameObject.GetComponent<Camera>().orthographicSize = _playerDistance;

        this.transform.position = new Vector3(GameObject.Find("Field").transform.position.x,
                                              _midpoint.y, -10.0f);
    }

    void Method2()
    {
        float x = Vector2.Distance(Left().position, Right().position);
        float y = Vector2.Distance(Top().position, Bottom().position);
        Vector3 m;

        if (x > y * 16/9)
        {
            m = MidPoint(Left().position, Right().position);
            gameObject.GetComponent<Camera>().orthographicSize = x / 3f;
        }
        else
        {
            m = MidPoint(Top().position, Bottom().position);
            gameObject.GetComponent<Camera>().orthographicSize = (y * 16 / 9) / 3f;
        }

        if (gameObject.GetComponent<Camera>().orthographicSize < CameraMinSize)
            gameObject.GetComponent<Camera>().orthographicSize = CameraMinSize;

        this.transform.position = new Vector3(m.x, m.y, -10.0f);
    }

    Vector3 MidPoint(Vector3 v1, Vector3 v2)
    {
        return (v1 + v2) * 0.5f;
    }

    Transform Top()
    {
        return _objects.OrderBy(x => x.transform.position.y).First();
    }

    Transform Bottom()
    {
        return _objects.OrderBy(x => x.transform.position.y).Last();
    }

    Transform Left()
    {
        return _objects.OrderBy(x => x.transform.position.x).Last();
    }

    Transform Right()
    {
        return _objects.OrderBy(x => x.transform.position.x).First();
    }
}