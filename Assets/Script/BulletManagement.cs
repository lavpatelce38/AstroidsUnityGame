using UnityEngine;
using System.Collections;

public class BulletManagement : MonoBehaviour {


	//------ Bullet Movement on Screen ------ //
	void LateUpdate()
	{
		if (transform.position.x < GameManager.leftBorder) {
			
			BulletDestory();
			return;
		}
		if (transform.position.x > GameManager.rightBorder) {
			BulletDestory();
			return;
			
		}
		if (transform.position.y > GameManager.topBorder) {
			BulletDestory();
			return;
			
		}
		if (transform.position.y < GameManager.bottomBorder) {
			BulletDestory();
			return;
			
		}
	}

	 void BulletDestory()
	{

		Destroy(this.gameObject);

	}
}
