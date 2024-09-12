using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject deathExplosion;
    public int pointValue;
    public AudioClip deathKnell; 

    // Start is called before the first frame update
    void Start()
    {
        pointValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        // rotating b/c z is upwards by default for particle effects 
        AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        Destroy(gameObject);
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
		else
		{
			Debug.Log("Collided with " + collider.tag);
		}
	}
	*/
	
}
