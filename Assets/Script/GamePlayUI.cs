using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{

	public Text life, Score, GameOverScore, GameOverHighScore;
	public GameObject GameOverPopup;

	GameManager gameManager;
	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		LifeSet ();

	}

	//------ Set Score Text ------ //
	public void ScoreSet ()
	{
		Score.text = "SCORE:" + gameManager.Score.ToString ();
	}
	//------ Set Life Text ------ //
	public void LifeSet ()
	{
		life.text = "LIFE:" + gameManager.PlayerLife.ToString ();
	}
	//------ GameOver ------ //
	public void GameOver ()
	{
		SoundManager.soundManagerObject.GameoverSound ();
		GameOverPopup.SetActive (true);
		GameOverScore.text = "SCORE:" + gameManager.Score.ToString ();
		if (gameManager.Score > gameManager.GetHighScore ()) {
			gameManager.SetHighScore ();
		}
		GameOverHighScore.text = "HIGHSCORE:" + gameManager.GetHighScore ().ToString ();
	}
	//------ MainMenu ------ //
	public void Mainmenu ()
	{
		SoundManager.soundManagerObject.PlayButtonSound ();
		Application.LoadLevel ("MainMenu");

	}
	
}
