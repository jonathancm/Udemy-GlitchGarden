using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] Defender defenderPrefab = null;

	// Cached References
	DefenderSpawner defenderSpawner = null;

	private void Start()
	{
		defenderSpawner = FindObjectOfType<DefenderSpawner>();
		LabelButtonWithCost();
	}

	private void LabelButtonWithCost()
	{
		Text costText = GetComponentInChildren<Text>();
		if (!costText)
		{
			Debug.LogError(name + " has no cost text, add missing object!");
		}
		else
		{
			costText.text = defenderPrefab.GetStarCost().ToString();
		}
	}

	private void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach(DefenderButton button in buttons)
		{
			button.GetComponent<SpriteRenderer>().color = Color.gray;
		}

		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		defenderSpawner.SetSelectedDefender(defenderPrefab);
	}
}
