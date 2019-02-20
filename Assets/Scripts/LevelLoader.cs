using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] float delayInSeconds = 4f;

	// State Variables
	int currentSceneIndex;

	// Use this for initialization
	void Start ()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		switch(currentSceneIndex)
		{
			case 0:
				StartCoroutine(WaitAndLoadNextScene());
				break;

			default:
				break;
		}
	}

	IEnumerator WaitAndLoadNextScene()
	{
		yield return new WaitForSeconds(delayInSeconds);
		LoadNextScene();
	}

	public void LoadNextScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public void RestartScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(currentSceneIndex);
	}

	public void LoadStartMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("StartScreen");
	}

	public void LoadOptionsScreen()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("OptionsScreen");
	}

	public void LoadGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level 1");
	}

	public void LoadLoseScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("GameOver");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
