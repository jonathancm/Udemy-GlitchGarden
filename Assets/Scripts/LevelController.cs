using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	// Configurable Parameters
	[SerializeField] GameObject winLabel = null;
	[SerializeField] GameObject loseLabel = null;
	[SerializeField] GameObject pauseCanvas = null;
	float revealLabelDelay = 2f;
	float loadNextSceneDelay = 5f;

	// Cached References
	LevelLoader levelLoader;
	AudioSource winSound;

	// State Variables
	int numberOfAttackers = 0;
	bool levelTimerFinished = false;
	bool loseConditionTriggered = false;
	bool winConditionTriggered = false;
	bool gamePaused;

	private void Start()
	{
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
		levelLoader = FindObjectOfType<LevelLoader>();
		winSound = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			PauseGame();
	}

	public void AttackerSpawned()
	{
		numberOfAttackers++;
	}

	public void AttackerDestroyed()
	{
		numberOfAttackers--;
		if (loseConditionTriggered == true)
		{
			return;
		}

		if (numberOfAttackers <= 0 && levelTimerFinished)
		{
			winConditionTriggered = true;
			StartCoroutine(HandleWinCondition());
		}
	}

	IEnumerator HandleWinCondition()
	{
		new WaitForSeconds(revealLabelDelay);
		winLabel.SetActive(true);
		winSound.Play();

		yield return new WaitForSeconds(loadNextSceneDelay);
		levelLoader.LoadNextScene();

	}

	public void HandleLoseCondition()
	{
		if(winConditionTriggered == false)
		{
			loseConditionTriggered = true;
			StartCoroutine(WaitAndLose());
		}
	}

	IEnumerator WaitAndLose()
	{
		yield return new WaitForSeconds(revealLabelDelay);
		loseLabel.SetActive(true);
		Time.timeScale = 0;
	}

	public void LevelTimerFinished()
	{
		levelTimerFinished = true;
		StopSpawners();
	}

	private void StopSpawners()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawners)
		{
			spawner.StopSpawning();
		}
	}

	public void PauseGame()
	{
		if(!pauseCanvas)
			return;

		if(loseConditionTriggered || winConditionTriggered)
			return;

		if(gamePaused)
		{
			pauseCanvas.SetActive(false);
			Time.timeScale = 1;
			gamePaused = false;
		}
		else
		{
			pauseCanvas.SetActive(true);
			Time.timeScale = 0;
			gamePaused = true;
		}
	}
}
