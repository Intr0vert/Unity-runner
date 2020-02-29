using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	private Vector2 targetPos;

	public float Yincrement;

	public float speed;
	public float maxHeight;
	public float minHeight;

	public int health = 3;

	public GameObject effect;
	public Animator animator;

	public void Start()
	{
		animator.SetFloat("Speed", 0f);

		targetPos = new Vector2(
			-4.5f,
			0f
			);
	
		transform.position = Vector2.MoveTowards(
			transform.position, 
			targetPos,
			speed * Time.deltaTime
		);
	}

    private void Update()
    {

    	if (health <= 0) {
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	}

		if (
			Input.GetKeyDown(KeyCode.UpArrow) &&
			transform.position.y < maxHeight
			) {
			Instantiate(effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(
				-4.5f, 
				transform.position.y + Yincrement
				);
		} else if (
			Input.GetKeyDown(KeyCode.DownArrow) &&
			transform.position.y > minHeight
			) {
			Instantiate(effect, transform.position, Quaternion.identity);
			targetPos = new Vector2(
				-4.5f, 
				transform.position.y - Yincrement
				);
		}

    	transform.position = Vector2.MoveTowards(
    		transform.position, 
    		targetPos,
    		speed * Time.deltaTime
    		);
    }
}