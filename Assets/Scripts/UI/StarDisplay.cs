using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] int stars = 100;
	TextMeshProUGUI starText;

	void Start () {
		starText = GetComponent<TextMeshProUGUI>();
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		starText.text = stars.ToString();
	}

	public bool HaveEnoughtStars(int amount)
	{
		return (stars >= amount);
	}

	public void AddStars(int amount)
	{
		stars += amount;
		UpdateDisplay();
	}

	public void SpendStars(int amount)
	{
		if (stars >= amount)
		{
			stars -= amount;
		}

		UpdateDisplay();
	}

}
