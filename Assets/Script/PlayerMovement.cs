using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{


	// Use this for initialization
	float rotationForce = 200f;
	float accelerationForce = 35f;

	float rotation, acceleration;
	Vector3 newPos;
	public GameObject Bullete;

	void Start ()
	{
		PlayerShieldActive ();

	}
	//------------Player Shield Active-------------//
	public void PlayerShieldActive ()
	{
		transform.GetComponent<PolygonCollider2D> ().enabled = false;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (PlayerDeactiveShild ());
	}
	//------------Player Shield Deative-------------//
	IEnumerator PlayerDeactiveShild ()
	{
		yield return new WaitForSeconds (3f);
		transform.GetComponent<PolygonCollider2D> ().enabled = true;
		transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = false;
	}
	// Update is called once per frame
	void Update ()
	{
		//------------Player movement And Fire Button-------------//
		#if CROSS_PLATFORM_INPUT
		rotation = -CrossPlatformInput.GetAxis ("Horizontal");
		acceleration = Mathf.Lerp (CrossPlatformInput.GetAxis ("Vertical") * accelerationForce, 0f, 0.8f);

		if (CrossPlatformInput.GetButtonDown ("Jump")) {
			BulleteFire ();
		}
		# else
		rotation = -Input.GetAxis ("Horizontal");
		acceleration = Mathf.Lerp (Input.GetAxis ("Vertical") * accelerationForce, 0f, 0.8f);

		if (Input.GetKeyDown (KeyCode.Space)) {
			BulleteFire ();
		}
		#endif



		PlayerBoundry ();
	}


	//------------Player Boundry-------------//

	void PlayerBoundry ()
	{
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
	void FixedUpdate ()
	{
		
		transform.Rotate (0f, 0f, rotation * Time.deltaTime * rotationForce);

		if (acceleration > 0) {
			GetComponent<Rigidbody2D>().velocity = (transform.up * acceleration);

		} 


	}
	//------------Bullete Fire------------//
	void BulleteFire ()
	{
		SoundManager.soundManagerObject.BulletFire ();
		Vector3 offsetForward = transform.up * 1f; 
		Vector3 finalPosition = transform.position + offsetForward;
		GameObject GBullete = (GameObject)Instantiate (Bullete, finalPosition, transform.rotation);
		GBullete.GetComponent<Rigidbody2D>().AddForce (transform.up * 800f);
	}



}
