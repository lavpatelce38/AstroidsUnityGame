using UnityEngine;
using System.Collections;

public class ParticalsManager : MonoBehaviour
{

	// Use this for initialization
	GameObject smallExplosionParticals, LargeExplosionParticals, PlayerExplosionParticals;
	private  static GameObject ParticalsManagerObj;
	void Start ()
	{
		//------ Set Particals ------ //
		LargeExplosionParticals = Resources.Load ("Particals/ExplosionLarge") as GameObject;
		smallExplosionParticals = Resources.Load ("Particals/ExplosionSmall") as GameObject;
		PlayerExplosionParticals = Resources.Load ("Particals/ExplosionPlayer") as GameObject;
		ParticalsManagerObj = this.gameObject;
	}
	public static ParticalsManager ParticalsManagerObject {
		get { return ParticalsManagerObj.GetComponent<ParticalsManager> (); }
	}
		
	//------ Large Explosion ------ //
	public void LargeExplosion (GameObject g)
	{
		Instantiate (LargeExplosionParticals, g.transform.position, Quaternion.identity);


	}
	//------ Small Explosion ------ //
	public void SmallExplosion (GameObject g)
	{
		Instantiate (smallExplosionParticals, g.transform.position, Quaternion.identity);
		
		
	}
	//------ Player Explosion ------ //
	public void PlayerExplosion (GameObject g)
	{
		GameObject gPartical = (GameObject)Instantiate (PlayerExplosionParticals, g.transform.position, Quaternion.identity);
		gPartical.transform.SetParent (g.transform);
		
		
	}
}
