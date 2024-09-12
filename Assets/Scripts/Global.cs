using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public int lives = -1;
    public GameObject lifeCount;

    public GameObject gameOver; 

    public GameObject ship; 

    public bool delete = true;

	// Start is called before the first frame update
	void Start()
    {
        score = 0;
        timer = 0;
        spawnPeriod = 5.0f;
        ufoSpawnPeriod = 5.0f; // change to higher number
		numberSpawnedEachPeriod = 4;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));

        foreach (Transform child in lifeCount.transform)
        {
            lives++;
        }
        
        //lives = 1;

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

            
            if (delete)
            {
				// ufo logic
				/*
                Instantiate(ufo, Camera.main.ScreenToWorldPoint(
                    new Vector3(horizontalPos, verticalPos, originInScreenCoords.z)), Quaternion.identity);
                */

				horizontalPos = UnityEngine.Random.Range(0.0f, width);
				//verticalPos = UnityEngine.Random.Range(0.0f, height);
				verticalPos = ship.transform.position.y;

				Instantiate(ufo, new Vector3(UnityEngine.Random.Range(-9.0f, 10.0f), 0, UnityEngine.Random.Range(-14.0f, 14.0f)), Quaternion.identity);


				delete = false;
            }
            

            if (delete)
            {
                // asteroid logic
                for (int i = 0; i < numberSpawnedEachPeriod; i++)
                {
                    horizontalPos = UnityEngine.Random.Range(0.0f, width);
                    //verticalPos = UnityEngine.Random.Range(0.0f, height);
                    verticalPos = ship.transform.position.y;

                    Instantiate(asteroid, new Vector3(UnityEngine.Random.Range(-9.0f, 10.0f), 0, UnityEngine.Random.Range(-14.0f, 14.0f)), Quaternion.identity);
                }
                delete = false;
            }
            
        }
    }

    public void shipLifeController()
    {
        bool lifeUsed = false;
        if (lives > 0)
        {
            Transform child = lifeCount.transform.GetChild(lives-1);
            child.gameObject.SetActive(false);
            lives--; 

            lifeUsed = true;

            if (lives <= 0)
            {
                lifeUsed = false;
            }
		}

        if (!lifeUsed)
        {
            Debug.Log("Game Over");
            GameOver g = gameOver.GetComponent<GameOver>();
            g.GameOverScreen(g.checkHighScore(score));

            Ship s = ship.GetComponent<Ship>();
            s.deactivate = true; 
			ship.transform.GetChild(1).gameObject.SetActive(false);
			ship.transform.GetChild(2).gameObject.SetActive(false);

			gameOver.gameObject.SetActive(true);
			
		}
    }
}
