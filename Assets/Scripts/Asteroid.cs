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
}
