using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour  {

    public static bool GameOver = false;

    void Update()
    {
        
        if (!GameOver)
            return;

        if (Input.GetAxisRaw("Action1") > 0 || Input.GetAxisRaw("Action2") > 0)
        {
            GameOver = false;
            Time.timeScale = 1f;
            Application.LoadLevel(1);
        }
    }
}
