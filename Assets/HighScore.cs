using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{

	//List<string> topScores = new List<string>();
    public GameObject scoreLst;
	public Button returnStart; 

    // Start is called before the first frame update
    void Start()
    {

		returnStart.onClick.AddListener(titleScreenShift);

		bool nullVal = false;
		string[] csv = { "test", "test"};

		for (int i = 0; i < 10; i++)
		{
            if (PlayerPrefs.GetString($"name_{i}") == "")
            {
				nullVal = true;

			} 

			else
			{
				csv = PlayerPrefs.GetString($"name_{i}").Split(',');
				if (int.Parse(csv[1]) == -1)
				{
					nullVal = true;
				}
			}
			
			if (nullVal)
            {
				scoreLst.GetComponent<TextMeshProUGUI>().text += $"{i+1}.\t None\n";
			}
			else
            {
				scoreLst.GetComponent<TextMeshProUGUI>().text += $"{i+1}.\t{csv[0]}\t{csv[1]}\n";
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void titleScreenShift()
	{
		SceneManager.LoadScene("TitleScreen");
	}
}
