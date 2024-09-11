using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Vector3 separation; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        separation = transform.position - ship.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + separation;
    }
}
