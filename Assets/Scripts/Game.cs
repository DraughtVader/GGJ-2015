using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour  {

    public static bool GameOver = false;
	public AudioClip DuringGameAudio;
	public AudioClip GameOverAudio;

    void Start()
	{
		this.gameObject.GetComponent<AudioSource>().clip = DuringGameAudio;
		audio.loop = true;
		audio.Play();
	}
	void Update()
    {
        
        if (!GameOver)
            return;

        if (Input.GetAxisRaw("Action1") > 0 || Input.GetAxisRaw("Action2") > 0)
        {
            GameOver = false;
            Time.timeScale = 1f;
            Application.LoadLevel(0);
        }

		if(GameOver)
		{
			audio.Pause();
			this.gameObject.GetComponent<AudioSource>().clip = GameOverAudio;
			audio.Play();
			audio.loop = false;
		}
    }
}
