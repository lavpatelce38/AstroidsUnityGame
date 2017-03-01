using UnityEngine;
using System.Collections;

public class BackGroundMovement : MonoBehaviour
{

	// Use this for initialization
	public float Speed;
	public Material Background_m;

	
	void Start ()
	{
		// Set BackGround with offset
		Background_m.SetTextureOffset ("_MainTex", new Vector2 (0f, 0f));
	}
	
	void Update ()
	{
		//BackGround Texture Movement using offset
		float offset = (Time.time) * Speed;
		Background_m.SetTextureOffset ("_MainTex", new Vector2 (0f, offset));
	}

}
