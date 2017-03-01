using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
	public Text HighScore;
	GameManager gameManager;
	void Start ()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		HighScore.text = "HIGH SCORE:" + gameManager.GetHighScore ().ToString ();
	}
	//------ PlayButton ------ //
	public void PlayButton ()
	{
		SoundManager.soundManagerObject.PlayButtonSound ();
		Application.LoadLevel ("GamePlay");
	}

}
