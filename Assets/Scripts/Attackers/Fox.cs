using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
	// Cached Reference
	Attacker attackComponent;
	Animator animator;

	private void Start()
	{
		attackComponent = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		GameObject otherObject = otherCollider.gameObject;

		// Shield statements
		if (!attackComponent) { return; }
		if (!animator) { return; }

		if(otherObject.GetComponent<Gravestone>())
		{
			animator.SetTrigger("jumpTrigger");
		}
		else if (otherObject.GetComponent<Defender>())
		{
			attackComponent.Attack(otherObject);
		}
	}
}
