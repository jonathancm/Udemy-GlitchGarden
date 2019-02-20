using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseCollider : MonoBehaviour
{
	// Cached References
	LifeDisplay lifeDisplay;

    // Start is called before the first frame update
    void Start()
    {
		lifeDisplay = FindObjectOfType<LifeDisplay>();
    }

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.GetComponent<Attacker>())
		{
			lifeDisplay.LoseLifePoints(1);
		}

		Destroy(otherCollider.gameObject);
	}
}
