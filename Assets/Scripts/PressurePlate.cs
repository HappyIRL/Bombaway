using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
	[SerializeField] private float affectRadius;
	private void OnCollisionEnter(Collider2D other)
	{
		Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, affectRadius);

		foreach (var collision in collisions)
		{
			var affectable = collision.GetComponent<IAffectable>();

			affectable?.OnActivate();

		}
	}
}
