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

	private void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;
		if (collider.CompareTag("Ship"))
		{
			// ship life lost logic 
			Debug.Log("Ship Hit by UFO");

			// destroying bullet after collision 
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("Collided with " + collider.tag);
		}
	}
}
