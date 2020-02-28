using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int damage = 1;
	public float speed;

	private void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) {
			// Player takes damage!
			other.GetComponent<Player>().health -= damage;
			Destroy(gameObject);
		}
	}

}
