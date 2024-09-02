using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    public GameObject bullet; 

    // Start is called before the first frame update
    void Start()
    {
      forceVector.x = 1.0f;
      rotationSpeed = 2.0f; 
    }

   void FixedUpdate()
   {
      // force thruster 
      if (Input.GetAxisRaw("Vertical") > 0)
      {
         GetComponent<Rigidbody>().AddRelativeForce(forceVector);
      }

      if (Input.GetAxis("Horizontal") > 0)
      {
         rotation += rotationSpeed;
         Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
         GetComponent<Rigidbody>().MoveRotation(rot);
      }
      else if (Input.GetAxis("Horizontal") < 0)
      {
         rotation -= rotationSpeed;
         Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
         GetComponent<Rigidbody>().MoveRotation(rot);
      }
   }

   // Update is called once per frame
   void Update()
   {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire! " + rotation); 

            // making sure bullet spawned at tip of ship instead of 
            // in the ship
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(rotation * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(rotation * Mathf.PI / 180); 

            // instantiate bullet 
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

            // initialize bullet script 
            BulletScript b = obj.GetComponent<BulletScript>();

            // set dir of bullet 
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            b.heading = rot; 

        }
   }
}
