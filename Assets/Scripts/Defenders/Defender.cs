using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] int starCost = 100;

	// Cached Reference
	StarDisplay starDisplay;

	private void Start()
	{
		starDisplay = FindObjectOfType<StarDisplay>();
	}

	public int GetStarCost()
	{
		return starCost;
	}

	public void AddStars(int amount)
	{
		if(starDisplay)
		{
			starDisplay.AddStars(amount);
		}
	}
}
