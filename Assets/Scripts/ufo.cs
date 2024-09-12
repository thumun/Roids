using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo : MonoBehaviour
{
	public int pointValue;
	public GameObject deathExplosion;
	public AudioClip deathKnell;

	public AudioClip bulletSound;

	public GameObject ship;
	public GameObject bullet;

	public float timer; 
	public float bulletSpawnPeriod;

	// Start is called before the first frame update
	void Start()
    {
		pointValue = 30;
		ship = GameObject.Find("Ship").gameObject;
		timer = 0;
		bulletSpawnPeriod = 6.0f; 

	}

    // Update is called once per frame
    void Update()
    {
		
		timer += Time.deltaTime;
		if (timer > bulletSpawnPeriod)
		{
			timer = 0;

			Vector3 spawnPos = gameObject.transform.position;
			spawnPos.x += 1.5f * Mathf.Cos(ship.transform.rotation.y * Mathf.PI / 180);
			spawnPos.z -= 1.5f * Mathf.Sin(ship.transform.rotation.y * Mathf.PI / 180);

			// instantiate bullet 
			AudioSource.PlayClipAtPoint(bulletSound, gameObject.transform.position);

			GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
		}

		//Debug.Log(ship.transform.position);
		transform.position = Vector3.MoveTowards(transform.position, ship.transform.position + new Vector3(1.5f, 0, 1.5f), 0.02f);

	}

	private void FixedUpdate()
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
		g.alienDeathCount--;

		Ship s = ship.GetComponent<Ship>();
		s.EnableForcefields();

		Destroy(gameObject);
	}

}
