using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    private GUIStyle buttonStyle; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 100,
            Screen.width - 10, 200));

        if (GUILayout.Button("New Game"))
        {
            SceneManager.LoadScene("GameplayScene");
        }
        if (GUILayout.Button("High score"))
        {
			SceneManager.LoadScene("HighScoreScreen");
        }
        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
            Debug.Log("Application.Quit() only works in build, not in editor");
        }
        GUILayout.EndArea();
    }

	private void OnEnable()
	{
		// set up player prefs 
	}
}
