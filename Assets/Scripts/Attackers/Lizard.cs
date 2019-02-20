using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
	// Cached Reference
	Attacker attackComponent;

	private void Start()
	{
		attackComponent = GetComponent<Attacker>();
	}

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		GameObject otherObject = otherCollider.gameObject;

		if (!attackComponent)
		{
			return;
		}

		if (otherObject.GetComponent<Defender>())
		{
			attackComponent.Attack(otherObject);
		}
	}
}
