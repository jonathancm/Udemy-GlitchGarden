using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	// Configurable Parameter
	[Tooltip("Our level timer in seconds")]
	[SerializeField] float levelTime = 10f;

	// Cached References
	Slider slider;
	LevelController levelController;

	// State Variables
	bool triggeredLevelFinished = false;

	private void Awake()
	{
		levelController = FindObjectOfType<LevelController>();
	}

	void Start()
    {
		slider = GetComponent<Slider>();
    }

    void Update()
    {
		bool timerFinished = false;
		float timeElapsed = 0f;

		// Shield Statements
		if(triggeredLevelFinished) { return; }
		if (!slider) { return; }

		timeElapsed = Time.timeSinceLevelLoad;
		slider.value = timeElapsed / levelTime;

		timerFinished = (timeElapsed >= levelTime);
		if (timerFinished && levelController)
		{
			levelController.LevelTimerFinished();
			triggeredLevelFinished = true;
		}

    }
}
