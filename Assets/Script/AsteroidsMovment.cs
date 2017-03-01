using UnityEngine;
using System.Collections;

public class AsteroidsMovment : MonoBehaviour
{

	// Use this for initialization
	float speed; 
	Vector3 newPos;

	public GameObject[]SubAsteriods;
	GamePlayUI GamePlayUIObj;
	GameManager GameManagerObj;
	GameObject asteriods;
	public void Start ()
	{ 
		GameManagerObj = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		if (GameManagerObj.ScenestateEnum == GameManager.SceneState.GamePlay) {
			GamePlayUIObj = GameObject.Find ("GamePlayUI").GetComponent<GamePlayUI> ();
			asteriods = GameObject.Find ("Asteriods");
		}

		//------- Random Speed----------//
		if (this.gameObject.CompareTag("LargeAsteroid"))
			speed = Random.Range (1.3f, 2.3f);
		else if (this.gameObject.CompareTag("MediumAsteroid"))
			speed = Random.Range (2.3f, 3.3f);
		else
			speed = Random.Range (3.3f, 4.3f);
		//------- Random movement----------//
		Vector3 v = Quaternion.AngleAxis (Random.Range (0.0f, 360.0f), Vector3.forward) * Vector3.up;
		GetComponent<Rigidbody2D>().velocity = v * speed;

		//----------------------Random Angle----------------//
		Vector3 euler = transform.eulerAngles;
		euler.z = Random.Range (0f, 360f);
		transform.eulerAngles = euler;

	}


	
	public void Update ()
	{
		//--------------------Boundry Check----------------------//
		transform.Rotate (Vector3.forward * Time.deltaTime * speed * 10f, Space.World);
		newPos = transform.position;
	
		if (transform.position.x < GameManager.leftBorder) {
			newPos.x = GameManager.rightBorder; 

		}
		if (transform.position.x > GameManager.rightBorder) {
			newPos.x = GameManager.leftBorder; 
				
		}
		if (transform.position.y > GameManager.topBorder) {
			newPos.y = GameManager.bottomBorder; 
		}
		if (transform.position.y < GameManager.bottomBorder) {
			newPos.y = GameManager.topBorder; 
		}
		transform.position = newPos;
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (GameManagerObj.ScenestateEnum == GameManager.SceneState.GamePlay) {
			//--------------------Bullete Enter----------------------//
			if (other.gameObject.CompareTag("Bullet")) {

				//----------- Check Asteroid Size--------------//
				if (this.gameObject.CompareTag("LargeAsteroid") || this.gameObject.CompareTag("MediumAsteroid")) {
					for (int i=0; i<2; i++) {
						GameObject SubObj = (GameObject)Instantiate (SubAsteriods [Random.Range (0, SubAsteriods.Length)], new Vector3 (transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
						SubObj.transform.SetParent (asteriods.transform);
					}
					if (this.gameObject.CompareTag("LargeAsteroid")) {
						GameManagerObj.Score++;
						GamePlayUIObj.ScoreSet ();
					} else {
						GameManagerObj.Score += 2;
						GamePlayUIObj.ScoreSet ();
					}
					
					SoundManager.soundManagerObject.ExplosionAsteriod ();
					ParticalsManager.ParticalsManagerObject.LargeExplosion (other.gameObject);
					Destroy (this.gameObject);


				} else {

					GameManagerObj.Score += 3;
					GamePlayUIObj.ScoreSet ();
					SoundManager.soundManagerObject.ExplosionAsteriod ();
					ParticalsManager.ParticalsManagerObject.SmallExplosion (other.gameObject);
					Destroy (this.gameObject);

				}
				Destroy (other.gameObject);
			}
			//--------------------Player Enter----------------------//
			if (other.gameObject.CompareTag("Player")) {

				GameManagerObj.PlayerLife--;
				GamePlayUIObj.LifeSet ();
				if (GameManagerObj.PlayerLife <= 0) {
					GamePlayUIObj.GameOver ();
					Destroy (other.gameObject);

				} else {
					SoundManager.soundManagerObject.PlayerExplosionSound ();
					ParticalsManager.ParticalsManagerObject.PlayerExplosion (other.gameObject);
					other.gameObject.GetComponent<PlayerMovement> ().PlayerShieldActive ();

				}
			}
		}
	}
}
