using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	public PlayerController player;

	public DeathMenu deathMenu;

	private Vector3 platformStartPoint;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;
	private ScoreManager scoreManager;
	private AudioSource backgroundMusic;
	private BackgroundScroller[] backgroundScrollers;

	private GameObject pauseButton;
	private Text endScore;

	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;

		scoreManager = FindObjectOfType<ScoreManager> ();
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
		backgroundScrollers = FindObjectsOfType<BackgroundScroller> ();

		pauseButton = GameObject.Find ("PauseButton");
		endScore = deathMenu.transform.FindChild ("EndScore").GetComponent<Text> ();
	}

	public void RestartGame()
	{
		scoreManager.scoreIncreasing = false;
		player.gameObject.SetActive (false);

		backgroundMusic.Pause ();
		for (int i = 0; i < backgroundScrollers.Length; i++) {
			backgroundScrollers[i].Pause ();
		}

		pauseButton.SetActive (false);
		deathMenu.gameObject.SetActive (true);
		endScore.text = "" + Mathf.Round(scoreManager.scoreCount);
	}

	public void Reset ()
	{
		backgroundMusic.Play ();
		for (int i = 0; i < backgroundScrollers.Length; i++) {
			backgroundScrollers[i].Scroll ();
		}
		deathMenu.gameObject.SetActive (false);
		pauseButton.SetActive (true);

		platformList = FindObjectsOfType<PlatformDestroyer> ();

		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		player.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;

		player.gameObject.SetActive (true);
		scoreManager.scoreCount = 0;
		scoreManager.scoreIncreasing = true;
	}
}
