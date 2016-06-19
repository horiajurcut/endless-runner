using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	private AudioSource backgroundMusic;

	void Start ()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
	}

	public void RestartGame ()
	{
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMainMenu ()
	{
		SceneManager.LoadScene (mainMenuLevel);
	}
}
