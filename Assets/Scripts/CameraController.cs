using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	// Use this for initialization
	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (
			thePlayer.transform.position.x,
			transform.position.y,
			transform.position.z
		);
	}
}
