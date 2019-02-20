using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] float spawnDelayMin = 1f;
	[SerializeField] float spawnDelayMax = 5f;
	[SerializeField] float startingDelay = 5f;
	[SerializeField] Attacker[] attackerPrefabs = null;

	// State Variables
	bool spawn = true;

	IEnumerator Start ()
	{
		// Starting delay
		yield return new WaitForSeconds(startingDelay);

		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies()
	{
		// Keep spawning as long as spawn is enabled
		while(spawn)
		{
			yield return new WaitForSeconds(Random.Range(spawnDelayMin, spawnDelayMax));
			SpawnAttacker();
		}
	}

	public void StopSpawning()
	{
		spawn = false;
	}

	private void SpawnAttacker()
	{
		int attackerIndex;

		// Shield Statements
		if(attackerPrefabs.Length <= 0) { return; }

		attackerIndex = Random.Range(0, attackerPrefabs.Length);
		Spawn(attackerPrefabs[attackerIndex]);
	}

	private void Spawn(Attacker attacker)
	{
		Attacker newAttacker = Instantiate(
					attacker,
					transform.position,
					transform.rotation) as Attacker;

		newAttacker.transform.parent = transform;
	}
}
