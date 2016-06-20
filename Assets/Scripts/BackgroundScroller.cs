using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float backgroundSpeed;

	private float speed;
	private Renderer rend;

	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<Renderer> ();

		float quadHeight = Camera.main.orthographicSize * 2.0f;
		float quadWidth = (quadHeight / Screen.height) * Screen.width;

		transform.localScale = new Vector3(quadWidth, quadHeight, 1);

		speed = backgroundSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 offset = new Vector2 (
			Time.time * speed,
			0f
		);

		rend.material.mainTextureOffset = offset;
	}

	public void Pause ()
	{
		speed = 0.1f;
	}

	public void Scroll ()
	{
		speed = backgroundSpeed;
	}
}
