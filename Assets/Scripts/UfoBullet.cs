using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBullet : MonoBehaviour
{
	public GameObject ship;

	// Start is called before the first frame update
	void Start()
	{
		ship = GameObject.Find("Ship").gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, ship.transform.position, 0.2f);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ship"))
		{
			Ship ship = other.gameObject.GetComponent<Ship>();

			ship.Die();
			// destroying bullet after collision 
			Destroy(gameObject);
		}
		else if (other.CompareTag("Forcefield"))
		{
			forcefield field = other.gameObject.GetComponent<forcefield>();
			field.collisionNum--;

			Destroy(gameObject);
		}

		// add logic for ufo 
		else
		{
			Debug.Log("Collided with " + other.tag);
		}
	}

	/*
	private void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;
		if (collider.CompareTag("Ship"))
		{
			Ship ship = collider.gameObject.GetComponent<Ship>();

			ship.Die();
			// destroying bullet after collision 
			Destroy(gameObject);
		}
		// add logic for ufo 
		else if (collider.CompareTag("Forcefield"))
		{
			forcefield field = collider.gameObject.GetComponent<forcefield>();
			field.collisionNum--; 
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("Collided with " + collider.tag);
		}
	}
	*/
}
