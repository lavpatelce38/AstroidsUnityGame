using UnityEngine;
using System.Collections;

public class AsteriodsManager : MonoBehaviour
{

	public GameObject[]bigAsteriods;
	public int totalNumber;
	GameObject asteriods;
	// Use this for initialization
	void Start ()
	{

		asteriods = GameObject.Find ("Asteriods");

	}
	//------ Asteroids Instant ------ //
	void AsteroidsObjectInstant ()
	{
		for (int i=0; i<totalNumber; i++) {
			GameObject gTemp = (GameObject)Instantiate (bigAsteriods [Random.Range (0, bigAsteriods.Length)], new Vector3 (Random.Range (GameManager.leftBorder, GameManager.rightBorder), Random.Range (GameManager.bottomBorder, GameManager.topBorder), 0f), Quaternion.identity);
			gTemp.transform.SetParent (asteriods.transform);

			
		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
	
		if (asteriods.gameObject.transform.childCount == 0) {
			AsteroidsObjectInstant ();
		}
	}
}
