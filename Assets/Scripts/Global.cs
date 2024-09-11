using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject ufo;
    public float timer;
    public float spawnPeriod;
    public float ufoSpawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoords;
    public int score;

    public GameObject ship; 

    public bool delete = true;

	// Start is called before the first frame update
	void Start()
    {
        score = 0;
        timer = 0;
        spawnPeriod = 5.0f;
        ufoSpawnPeriod = 5.0f; // change to higher number
		numberSpawnedEachPeriod = 3;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));

        ship = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnPeriod)
        {
            timer = 0;
            float width = Screen.width;
            float height = Screen.height;

			float horizontalPos = UnityEngine.Random.Range(0.0f, width);
			float verticalPos = UnityEngine.Random.Range(0.0f, height);

            /*
            if (delete)
            {
                // ufo logic
                Instantiate(ufo, Camera.main.ScreenToWorldPoint(
                    new Vector3(horizontalPos, verticalPos, originInScreenCoords.z)), Quaternion.identity);
                delete = false;
            }
            */

            if (delete)
            {
                // asteroid logic
                for (int i = 0; i < numberSpawnedEachPeriod; i++)
                {
                    horizontalPos = UnityEngine.Random.Range(0.0f, width);
                    //verticalPos = UnityEngine.Random.Range(0.0f, height);
                    verticalPos = ship.transform.position.y;

                    Debug.Log(verticalPos);

                    Instantiate(asteroid, new Vector3(UnityEngine.Random.Range(-9.0f, 10.0f), 0, UnityEngine.Random.Range(-14.0f, 14.0f)), Quaternion.identity);
                }
                delete = false;
            }
            
        }
    }

    /*
	void OnDisable()
	{
        List<int> topScores = new List<int>();  
        for (int i = 0; i < 10; i++)
        {
            topScores.Add(Int32.Parse(PlayerPrefs.GetString("score_" + i)));
        }

        topScores.Sort();

        int indx = -1; 
        for (int i = 0; i < 10; i++)
        {
            if (score < topScores[i])
            {
                indx = i-1; 
                break;
            } 

            else if (topScores[i] == 0)
            {
                indx = i;
                break;
            }
        }

        // set score 

        PlayerPrefs.SetInt("score", 0);	
	}
    */
}
