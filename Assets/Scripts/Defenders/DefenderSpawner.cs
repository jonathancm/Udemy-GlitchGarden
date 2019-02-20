using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	// Cached references
	Defender defender = null;
	StarDisplay starDisplay = null;

	// State Variables
	GameObject defenderParent = null;
	const string DEFENDER_PARENT_NAME = "Defenders";

	private void Start()
	{
		starDisplay = FindObjectOfType<StarDisplay>();
		CreateDefenderParent();
	}

	private void CreateDefenderParent()
	{
		defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
		if (!defenderParent)
		{
			defenderParent = new GameObject(DEFENDER_PARENT_NAME);
		}
	}

	private void OnMouseDown()
	{
		AttemptToPlaceDefenderAt(GetSquareClicked());
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
		Vector2 gridPos = SnapToGrid(worldPos);

		return gridPos;
	}

	private Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);

		return new Vector2(newX, newY);
	}

	public void SetSelectedDefender(Defender defenderToSelect)
	{
		defender = defenderToSelect;
	}

	private void AttemptToPlaceDefenderAt(Vector2 gridPos)
	{
		int defenderCost;

		if (!defender){ return; }
		if (!starDisplay) { return; }

		defenderCost = defender.GetStarCost();
		if(starDisplay.HaveEnoughtStars(defenderCost))
		{
			SpawnDefender(gridPos);
			starDisplay.SpendStars(defenderCost);
		}
	}

	private void SpawnDefender(Vector2 gridPosition)
	{
		Defender newDefender;

		if (!defender) { return; }
		
		newDefender = Instantiate(
			defender, 
			gridPosition, 
			Quaternion.identity) as Defender;

		newDefender.transform.parent = defenderParent.transform;
	}
}
