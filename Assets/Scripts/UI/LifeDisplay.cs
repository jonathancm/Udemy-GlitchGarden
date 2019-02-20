using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
	// Configurable Parameters
	[SerializeField] int baseLives = 3;

	// State Variables
	int lifePoints;

	// Cached References
	LevelController levelController;
	TextMeshProUGUI lifeText;

    // Start is called before the first frame update
    void Start()
	{
		levelController = FindObjectOfType<LevelController>();
		lifeText = GetComponent<TextMeshProUGUI>();

		lifePoints = baseLives - PlayerPrefsController.GetDifficulty();
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		if (lifeText)
		{
			lifeText.text = lifePoints.ToString();
		}
	}

	public void LoseLifePoints(int amount)
	{
		lifePoints -= amount;
		if (lifePoints <= 0)
		{
			lifePoints = 0;
			UpdateDisplay();
			levelController.HandleLoseCondition();
		}
		else
		{
			UpdateDisplay();
		}
	}
}
