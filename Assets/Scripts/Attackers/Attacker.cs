using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	// Stats
	float currentSpeed = 1f;

	// Cached References
	GameObject currentTarget;
	Animator animator;
	LevelController levelController;

	private void Awake()
	{
		levelController = FindObjectOfType<LevelController>();

		if (levelController)
		{
			levelController.AttackerSpawned();
		}
	}

	void Start () {
		animator = GetComponent<Animator>();
	}

	private void OnDestroy()
	{
		if (levelController)
		{
			levelController.AttackerDestroyed();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		Move();
		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void Move()
	{
		transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
	}

	public void SetMovementSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void Attack(GameObject target)
	{
		animator.SetBool("isAttacking", true);
		currentTarget = target;
	}

	public void StrikeCurrentTarget(int damage)
	{
		Health health;
		if (!currentTarget) { return; }

		health = currentTarget.GetComponent<Health>();
		if(!health) { return; }

		health.DealDamage(damage);
	}
}
