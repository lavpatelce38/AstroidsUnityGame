using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

	// Use this for initialization
	private static SoundManager _instance ;
	GameObject BackGroundSound, Sfx1, Sfx2, Sfx3, Sfx4, Sfx5, Sfx6;
	private  static GameObject SoundManagerObj;

	void Awake ()
	{
		if (!_instance)
			_instance = this;
		else
			Destroy (this.gameObject);
		
		
		DontDestroyOnLoad (this.gameObject);
	}

	public static SoundManager soundManagerObject {
		get { return SoundManagerObj.GetComponent<SoundManager> (); }
	}

	void Start ()
	{
		// ---------- BackGround Sound object ---------- //
		BackGroundSound = GameObject.Find ("SoundManager/BackGround");
		// ---------- sfx sounds object ---------- //
		Sfx1 = GameObject.Find ("SoundManager/Sfx1");
		Sfx2 = GameObject.Find ("SoundManager/Sfx2");
		Sfx3 = GameObject.Find ("SoundManager/Sfx3");
		Sfx4 = GameObject.Find ("SoundManager/Sfx4");
		Sfx5 = GameObject.Find ("SoundManager/Sfx5");
		Sfx6 = GameObject.Find ("SoundManager/Sfx6");
		SoundManagerObj = GameObject.Find ("SoundManager");

		BackGroundSoundPlay ();
	}
	// ---------- Play Background Sound ---------- //
	public IEnumerator playBackGroundSfX (string SoundName, bool loop, float volume=1f)
	{
		AudioClip Clip;
		yield return Clip = (AudioClip)Resources.Load ("Sound/" + SoundName);

		BackGroundSound.GetComponent<AudioSource> ().loop = loop;
		BackGroundSound.GetComponent<AudioSource> ().clip = Clip;
		BackGroundSound.GetComponent<AudioSource> ().Play ();
		BackGroundSound.GetComponent<AudioSource> ().volume = volume;
	
		
		
		
	}
	// ---------- Play Sfx ---------- //
	public IEnumerator PlayMusicSfx (string SoundName, bool loop, float volume=1f)
	{
		
		
		AudioClip Clip;
		yield return Clip = (AudioClip)Resources.Load ("Sound/" + SoundName);
			
		if (!Sfx1.GetComponent<AudioSource> ().isPlaying) {
			Sfx1.GetComponent<AudioSource> ().loop = loop;
			Sfx1.GetComponent<AudioSource> ().clip = Clip;
			Sfx1.GetComponent<AudioSource> ().Play ();
			Sfx1.GetComponent<AudioSource> ().volume = volume;
		} else if (!Sfx2.GetComponent<AudioSource> ().isPlaying) {
			Sfx2.GetComponent<AudioSource> ().loop = loop;
			Sfx2.GetComponent<AudioSource> ().clip = Clip;
			Sfx2.GetComponent<AudioSource> ().Play ();
			Sfx2.GetComponent<AudioSource> ().volume = volume;
		} else if (!Sfx3.GetComponent<AudioSource> ().isPlaying) {
			Sfx3.GetComponent<AudioSource> ().loop = loop;
			Sfx3.GetComponent<AudioSource> ().clip = Clip;
			Sfx3.GetComponent<AudioSource> ().Play ();
			Sfx3.GetComponent<AudioSource> ().volume = volume;
		} else if (!Sfx4.GetComponent<AudioSource> ().isPlaying) {
			Sfx4.GetComponent<AudioSource> ().loop = loop;
			Sfx4.GetComponent<AudioSource> ().clip = Clip;
			Sfx4.GetComponent<AudioSource> ().Play ();
			Sfx4.GetComponent<AudioSource> ().volume = volume;
		} else if (!Sfx5.GetComponent<AudioSource> ().isPlaying) {
			Sfx5.GetComponent<AudioSource> ().loop = loop;
			Sfx5.GetComponent<AudioSource> ().clip = Clip;
			Sfx5.GetComponent<AudioSource> ().Play ();
			Sfx5.GetComponent<AudioSource> ().volume = volume;
		} else if (!Sfx6.GetComponent<AudioSource> ().isPlaying) {
			Sfx6.GetComponent<AudioSource> ().loop = loop;
			Sfx6.GetComponent<AudioSource> ().clip = Clip;
			Sfx6.GetComponent<AudioSource> ().Play ();
			Sfx6.GetComponent<AudioSource> ().volume = volume;
		}

			

	}

	// ---------- BackGround Sound Set ---------- //
	public void BackGroundSoundPlay ()
	{ 
		StartCoroutine (playBackGroundSfX ("BackGround", true, 1f));
	}
	// ---------- Bullet Fire Sound Set ---------- //
	public void BulletFire ()
	{
		StartCoroutine (PlayMusicSfx ("Fire", false, 0.8f));

	}
	// ---------- Player Explosion Sound Set ---------- //
	public void PlayerExplosionSound ()
	{
		StartCoroutine (PlayMusicSfx ("Player", false, 0.5f));
		
	}
	// ---------- Asteroids Explosion Sound Set ---------- //
	public void ExplosionAsteriod ()
	{
		StartCoroutine (PlayMusicSfx ("Blast", false, 0.3f));
		
	}
	// ---------- Play button Sound Set ---------- //
	public void PlayButtonSound ()
	{
		StartCoroutine (PlayMusicSfx ("Play", false, 0.3f));
		
	}
	// ---------- GameOver Sound Set ---------- //
	public void GameoverSound ()
	{
		StartCoroutine (PlayMusicSfx ("GameOver", false, 0.2f));
		
	}
		
		



}
