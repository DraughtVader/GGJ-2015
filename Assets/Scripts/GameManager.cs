using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
    }
}
