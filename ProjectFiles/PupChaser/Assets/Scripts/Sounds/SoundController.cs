using UnityEngine;
using System.Collections;

public enum sounds{
	playerHurt,
	playerDie,
	playerSword,
	playerDash,
	playerCharged,
	playerFireball,
	playerBigFireball,
	playerShield,
	playerCollectHeart,
	goblinHurt,
	goblinDie,
	goblinExplode,
	goblinShoot,
	spiderDie,
	spiderHurt,
	spiderShoot,
	snakeHurt,
	snakeDie,
	snakeShoot,
	berserkerDie,
	berserkerAttack,
	berserkerHurt
}

public class SoundController : MonoBehaviour {


	public AudioClip soundPlayerHurt;
	public AudioClip soundPlayerDie;
	public AudioClip soundPlayerSword1;
	public AudioClip soundPlayerSword2;
	public AudioClip soundPlayerSword3;
	public AudioClip soundPlayerDash;
	public AudioClip soundPlayerCharged;
	public AudioClip soundPlayerFireball;
	public AudioClip soundPlayerBigFireball;
	public AudioClip soundPlayerShield;
	public AudioClip soundPlayerCollectHeart;
	public AudioClip soundGoblinHurt;
	public AudioClip soundGoblinDie;
	public AudioClip soundGoblinExplode;
	public AudioClip soundGoblinShoot;
	public AudioClip soundSpiderDie;
	public AudioClip soundSpiderHurt;
	public AudioClip soundSpiderShoot;
	public AudioClip soundSnakeHurt;
	public AudioClip soundSnakeDie;
	public AudioClip soundSnakeShoot;
	public AudioClip soundBerserkerDie;
	public AudioClip soundBerserkerAttack;
	public AudioClip soundBerserkerHurt;

	public AudioSource aSource;

	public static SoundController instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
	}

	public static void PlaySound(sounds currentSound)
	{
		switch (currentSound)
		{
			//player
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
		case sounds.playerFireball:
		{
			instance.aSource.PlayOneShot(instance.soundPlayerFireball);
		}
			break;
		case sounds.playerBigFireball:
		{
			instance.aSource.PlayOneShot(instance.soundPlayerBigFireball);
		}
			break;
		case sounds.playerCharged:
		{
			instance.aSource.PlayOneShot(instance.soundPlayerCharged);
		}
			break;
		case sounds.playerShield:
		{
			instance.aSource.PlayOneShot(instance.soundPlayerShield);
		}
			break;
		case sounds.playerCollectHeart:
		{
			instance.aSource.PlayOneShot(instance.soundPlayerCollectHeart);
		}
			break;
			//goblin
		case sounds.goblinHurt:
		{
			instance.aSource.PlayOneShot(instance.soundGoblinHurt);
		}
			break;
		case sounds.goblinDie:
		{
			instance.aSource.PlayOneShot(instance.soundGoblinDie);
		}
			break;
		case sounds.goblinShoot:
		{
			instance.aSource.PlayOneShot(instance.soundGoblinShoot);
		}
			break;
		case sounds.goblinExplode:
		{
			instance.aSource.PlayOneShot(instance.soundGoblinExplode);
		}
			break;
			//spider
		case sounds.spiderDie:
		{
			instance.aSource.PlayOneShot(instance.soundSpiderDie);
		}
			break;
		case sounds.spiderHurt:
		{
			instance.aSource.PlayOneShot(instance.soundSpiderHurt);
		}
			break;
		case sounds.spiderShoot:
		{
			instance.aSource.PlayOneShot(instance.soundSpiderShoot);
		}
			break;
			//snake
		case sounds.snakeDie:
		{
			instance.aSource.PlayOneShot(instance.soundSnakeDie);
		}
			break;
		case sounds.snakeHurt:
		{
			instance.aSource.PlayOneShot(instance.soundSnakeHurt);
		}
			break;
		case sounds.snakeShoot:
		{
			instance.aSource.PlayOneShot(instance.soundSnakeShoot);
		}
			break;
		case sounds.berserkerAttack:
		{
			instance.aSource.PlayOneShot(instance.soundBerserkerAttack);
		}
			break;
		case sounds.berserkerDie:
		{
			instance.aSource.PlayOneShot(instance.soundBerserkerDie);
		}
			break;
		case sounds.berserkerHurt:
		{
			instance.aSource.PlayOneShot(instance.soundBerserkerHurt);
		}
			break;
			
		}
}
}