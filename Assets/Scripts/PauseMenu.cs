using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;

	private AudioSource backgroundMusic;
	private GameObject pauseButton;

	void Start ()
	{
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
		pauseButton = GameObject.Find ("PauseButton");
	}

	public void PauseGame ()
	{
		Time.timeScale = 0f;

		pauseButton.SetActive (false);
		pauseMenu.SetActive (true);

		backgroundMusic.Pause ();
	}

	public void ResumeGame ()
	{
		Time.timeScale = 1f;

		pauseButton.SetActive (true);
		pauseMenu.SetActive (false);

		backgroundMusic.Play ();
	}

	public void RestartGame ()
	{
		Time.timeScale = 1f;

		pauseButton.SetActive (true);
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
