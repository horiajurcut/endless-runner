using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;

	private AudioSource backgroundMusic;

	void Start ()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
	}

	public void PauseGame ()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
		backgroundMusic.Pause ();
	}

	public void ResumeGame ()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		backgroundMusic.Play ();
	}

	public void RestartGame ()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		FindObjectOfType<GameManager> ().Reset ();

		if (!backgroundMusic.isPlaying) {
			backgroundMusic.Play ();
		}
	}

	public void QuitToMainMenu ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenuLevel);
	}
}
