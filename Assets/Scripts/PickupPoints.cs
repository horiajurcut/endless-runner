using UnityEngine;
using System.Collections;

public class PickupPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager scoreManager;
	private AudioSource pickupSound;

	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
		pickupSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			scoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);

			if (pickupSound.isPlaying) {
				pickupSound.Stop ();
				pickupSound.Play ();
			} else {
				pickupSound.Play ();
			}
		}
	}
}
