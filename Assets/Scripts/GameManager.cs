using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	public PlayerController player;

	private Vector3 platformStartPoint;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame()
	{
		StartCoroutine ("RestartGameCoroutine");	
	}

	public IEnumerator RestartGameCoroutine()
	{
		player.gameObject.SetActive (false);

		yield return new WaitForSeconds (0.5f);

		platformList = FindObjectsOfType<PlatformDestroyer> ();

		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		player.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;

		player.gameObject.SetActive (true);
	}
}
