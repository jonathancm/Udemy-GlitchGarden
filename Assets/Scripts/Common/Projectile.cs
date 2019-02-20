using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Configurable Parameters
	[SerializeField] int projectileDamage = 1;
	[SerializeField] float speedTranslate = 1f;
	[SerializeField] float speedRotate = 90f;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speedTranslate * Time.deltaTime, Space.World);
		transform.Rotate(Vector3.forward, speedRotate * Time.deltaTime, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		var attacker = otherCollider.gameObject.GetComponent<Attacker>();
		var health = otherCollider.gameObject.GetComponent<Health>();

		if (attacker && health)
		{
			health.DealDamage(projectileDamage);
			Destroy(gameObject);
		}
	}
}
