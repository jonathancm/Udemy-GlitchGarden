using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] int startingHealth = 5;
	[SerializeField] GameObject deathVFX = null;
	[SerializeField] float hitFlashPeriod = 0.1f;
	[SerializeField] GameObject[] partsWithSprites = null;

	// State Variables
	int health = 1;

	private void Start()
	{
		health = startingHealth;
	}

	public void DealDamage(int damage)
	{
		health -= damage;
		if(health <= 0)
		{
			Die();
		}
		else
		{
			ProcessHit();
		}
	}

	private void Die()
	{
		PlayDeathVFX();
		Destroy(gameObject);
	}

	private void PlayDeathVFX()
	{
		GameObject deathVFXObject;

		if(!deathVFX) { return; }

		deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
		Destroy(deathVFXObject, 1f);
	}

	private void ProcessHit()
	{
		if(partsWithSprites == null || partsWithSprites.Length == 0)
			return;

		
		StartCoroutine(ColorFlash());
	}

	IEnumerator ColorFlash()
	{
		SpriteRenderer spriteRenderer = null;
		Color flashColor = new Color(1, 0.5f, 0.5f);

		foreach(var bodyPart in partsWithSprites)
		{
			spriteRenderer = bodyPart.GetComponent<SpriteRenderer>();

			if(spriteRenderer)
				spriteRenderer.color = flashColor;
		}

		
		yield return new WaitForSeconds(hitFlashPeriod);

		foreach(var bodyPart in partsWithSprites)
		{
			spriteRenderer = bodyPart.GetComponent<SpriteRenderer>();

			if(spriteRenderer)
				spriteRenderer.color = Color.white;
		}
	}
}
