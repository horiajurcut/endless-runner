using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	public PlayerController player;

	public DeathMenu deathMenu;

	private Vector3 platformStartPoint;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;
	private ScoreManager scoreManager;
	private AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;

		scoreManager = FindObjectOfType<ScoreManager> ();
		backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
	}

	public void RestartGame()
	{
		scoreManager.scoreIncreasing = false;
		player.gameObject.SetActive (false);

		deathMenu.gameObject.SetActive (true);
		backgroundMusic.Pause ();
	}

	public void Reset ()
	{
		deathMenu.gameObject.SetActive (false);
		backgroundMusic.Play ();

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

//	public IEnumerator RestartGameCoroutine()
//	{
//		scoreManager.scoreIncreasing = false;
//		player.gameObject.SetActive (false);
//
//		yield return new WaitForSeconds (0.5f);
//
//		platformList = FindObjectsOfType<PlatformDestroyer> ();
//
//		for (int i = 0; i < platformList.Length; i++) {
//			platformList [i].gameObject.SetActive (false);
//		}
//
//		player.transform.position = playerStartPoint;
//		platformGenerator.position = platformStartPoint;
//
//		player.gameObject.SetActive (true);
//		scoreManager.scoreCount = 0;
//		scoreManager.scoreIncreasing = true;
//	}
}
