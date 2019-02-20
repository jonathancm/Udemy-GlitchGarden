using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField] GameObject projectile = null;
	[SerializeField] GameObject gun = null;
	AttackerSpawner myLaneSpawner;
	Animator animator;

	private void Start()
	{
		SetLaneSpawner();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (IsAttackerInLane())
		{
			animator.SetBool("isAttacking", true);
		}
		else
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void SetLaneSpawner()
	{
		float spawnerPosY = 0f;
		float posY = 0f;
		float distance = 0f;
		bool isCloseEnough = false;

		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		posY = transform.position.y;
		foreach (AttackerSpawner spawner in spawners)
		{
			spawnerPosY = spawner.transform.position.y;
			distance = Mathf.Abs(spawnerPosY - posY);
			isCloseEnough = (distance <= Mathf.Epsilon);

			if (isCloseEnough)
			{
				myLaneSpawner = spawner;
				break;
			}
		}
	}

	private bool IsAttackerInLane()
	{
		if (!myLaneSpawner)
		{
			return false;
		}

		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void Fire()
	{
		GameObject newProjectile = Instantiate(
			projectile,
			gun.transform.position,
			gun.transform.rotation) as GameObject;

		newProjectile.transform.parent = transform;
	}
}
