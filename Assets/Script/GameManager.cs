using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
	public static float leftBorder, rightBorder, topBorder, bottomBorder;
	float offSet = 0.4f;
	[HideInInspector]
	public int PlayerLife;
	[HideInInspector]
	public int Score;
	public SceneState ScenestateEnum;
	// Use this for initialization
	public enum SceneState{
		MainMenu,
		GamePlay
	}

	void Awake ()
	{
	
		leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).x - offSet;
		rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0)).x + offSet;
		topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0)).y + offSet;
		bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0)).y - offSet;
		PlayerLife = 3;
		Score=0;

		if(!PlayerPrefs.HasKey("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore",0);
		}
	}
	//------ Set HighScore ------ //
	public void SetHighScore()
	{
		PlayerPrefs.SetInt("HighScore",Score);
	}
	//------ Get HighScore ------ //
	public int GetHighScore()
	{
		int highscore=PlayerPrefs.GetInt("HighScore");
		return highscore;
	}
	
	// Update is called once per frame
}
