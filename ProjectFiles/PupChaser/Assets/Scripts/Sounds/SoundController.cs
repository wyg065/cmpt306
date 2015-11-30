using UnityEngine;
using System.Collections;

public enum sounds{
	playerHurt,
	playerDie,
	playerSword,
	playerDash
}

public class SoundController : MonoBehaviour {


	public AudioClip soundPlayerHurt;
	public AudioClip soundPlayerDie;
	public AudioClip soundPlayerSword1;
	public AudioClip soundPlayerSword2;
	public AudioClip soundPlayerSword3;
	public AudioClip soundPlayerDash;

	public AudioSource aSource;

	public static SoundController instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
	}

	public static void PlaySound(sounds currentSound)
	{
		switch (currentSound) {
		case sounds.playerSword:
		{
			int randomNum =  Random.Range (1, 4);
			if(randomNum == 1)
			{
				instance.aSource.PlayOneShot (instance.soundPlayerSword1);
			}
			else if (randomNum == 2)
			{
				instance.aSource.PlayOneShot (instance.soundPlayerSword2);
			}
			else if (randomNum == 3)
			{
				instance.aSource.PlayOneShot (instance.soundPlayerSword3);
			}
		}
			break;
		case sounds.playerDash:
		{
			instance.aSource.PlayOneShot (instance.soundPlayerDash);
				
		}
			break;
		case sounds.playerHurt:
		{
			instance.aSource.PlayOneShot (instance.soundPlayerHurt);
				
		}
			break;
		case sounds.playerDie:
		{
			instance.aSource.PlayOneShot (instance.soundPlayerDie);
				
		}
			break;
		}
	}
}
