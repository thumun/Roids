using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score
{
	public int ScoreNumber { get; set; }
	public string Name { get; set; }

    public Score(int scoreNumber, string name)
    {
		ScoreNumber = scoreNumber;
		Name = name;
    }

    public Score(string csv)
    {
		var items = csv.Split(',');
		Name = items[0];
		ScoreNumber = Int32.Parse(items[1]);

	}

    public string stringify()
	{
		return $"{Name},{ScoreNumber}";
	}
}

    public class GameOver : MonoBehaviour
{
	public Button gameOver;
    public GameObject highScoreUI;
    public GameObject gameOverScreen;
	public GameObject inputName;

	private int score;
	bool returnVal = false;


	List<Score> topScores = new List<Score>();
	//List<string> topNames = new List<string>();

	// Start is called before the first frame update
	void Start()
    {
        gameOver.onClick.AddListener(ReturntoTitle);        
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkHighScore(int score)
    {
		topScores.Clear(); 
		for (int i = 0; i < 10; i++)
		{
			string csv = PlayerPrefs.GetString($"name_{i}");

			if (csv != "")
			{
				topScores.Add(new Score(csv));
			}
			else
			{
				topScores.Add(new Score(-1, ""));
			}

		}

		topScores = topScores.OrderBy(x => x.ScoreNumber).ToList();

		if (score > topScores[topScores.Count-1].ScoreNumber)
		{
			this.score = score;
			returnVal = true;
		}

		return returnVal; 
    }

    public void GameOverScreen(bool highScore)
    {
		highScoreUI.gameObject.SetActive(highScore);
		gameOver.gameObject.SetActive(true);

		gameOverScreen.SetActive(!highScore);
	}

    void ReturntoTitle()
    {
        Debug.Log("Return Btn clicked");
        SceneManager.LoadScene("TitleScreen");
    }

	private void OnDisable()
	{

		if (returnVal)
		{
			Score newHighScore = new Score(score, inputName.GetComponent<TMP_InputField>().text);
			topScores.Add(newHighScore);

			topScores = topScores.OrderByDescending(x => x.ScoreNumber).Take(10).ToList();

			for(int i = 0; i < topScores.Count; i++)
			{
				PlayerPrefs.SetString($"name_{i}", topScores[i].stringify());
			}
		}

		PlayerPrefs.Save();
	}

}
