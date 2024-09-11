using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

   public Vector3 thrust;
   public Quaternion heading; 

    // Start is called before the first frame update
    void Start()
    {
        thrust.x = 400.0f;

        // travel towards x axis 
        GetComponent<Rigidbody>().drag = 0; 

        // setting dir of travel 
        GetComponent<Rigidbody>().MoveRotation(heading);

        // applying thrust & no need to apply again b/c will not decelerate 
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;
        if (collider.CompareTag("Asteroid"))
        {
            Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
            
            roid.Die();
            // destroying bullet after collision 
            Destroy(gameObject);
        }
        // add logic for ufo 
        else
        {
            Debug.Log("Collided with " + collider.tag);
        }
	}
}
