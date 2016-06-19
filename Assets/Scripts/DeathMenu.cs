using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame ()
	{
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMainMenu ()
	{
		SceneManager.LoadScene (mainMenuLevel);
	}
}
