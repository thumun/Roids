using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefield : MonoBehaviour
{

    //public float timer;
    //public float end; 

    public int collisionNum; 

    // Start is called before the first frame update
    void Start()
    {
        collisionNum = 0;

	}

    // Update is called once per frame
    void Update()
    {
        if (collisionNum < 0)
        {
            this.gameObject.SetActive(false);
        }
        /*
        timer += 1;
        if (timer > end)
        {
            timer = 0; 
            this.gameObject.SetActive(false);
        }
        */
    }

	/*
	private void OnCollisionEnter(Collider other)
	{
		if (CompareTag("Asteroid"))
		{
            Asteroid roid = other.gameObject.GetComponent<Asteroid>();
            roid.Die();
			collisionNum++;
		}

		else if (CompareTag("Ufo"))
        {
            ufo ufo = other.gameObject.GetComponent<ufo>();
            ufo.Die();
			collisionNum++;
		}

		else if (CompareTag("UfoBullet"))
        {
            Destroy(other.gameObject);
			collisionNum++;
		}
	}
	*/

	/*
	private void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;

		//Debug.Log("collided with + " collider.tag);

		if (collider.CompareTag("Asteroid"))
		{
			Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
			roid.Die();
			collisionNum++;
		}

		else if (collider.CompareTag("Ufo"))
		{
			ufo ufo = collider.gameObject.GetComponent<ufo>();
			ufo.Die();
			collisionNum++;
		}

		else if (collider.CompareTag("UfoBullet"))
		{
			Destroy(collider.gameObject);
			collisionNum++;
		}

		Debug.Log("Collided with " + collider.tag);

	}
	*/


}
