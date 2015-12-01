using UnityEngine;
using System.Collections;

public class SpawnGoblinBullet : MonoBehaviour {

	public GameObject weakBulletPrefab;
	public GameObject mediumBulletPrefab;
	public GameObject strongBulletPrefab;
	
	public GameObject spawnedWeakBullet;
	public GameObject spawnedMediumBullet;
	public GameObject spawnedStrongBullet;

	[HideInInspector]
	public bool spawnWeakBullet;
	[HideInInspector]
	public bool spawnMediumBullet;
	[HideInInspector]
	public bool spawnStrongBullet;

	[HideInInspector]
	public bool canSpawnWeak;
	[HideInInspector]
	public bool canSpawnMedium;
	[HideInInspector]
	public bool canSpawnStrong;

	[HideInInspector]
	public bool facingUp;
	[HideInInspector]
	public bool facingDown;
	[HideInInspector]
	public bool facingLeft;
	[HideInInspector]
	public bool facingRight;

	// Use this for initialization
	void Start () {

		spawnWeakBullet = false;
		spawnMediumBullet = false;
		spawnStrongBullet = false;

		canSpawnWeak = true;
		canSpawnMedium = true;
		canSpawnStrong = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spawnWeakBullet)
		{
			if(canSpawnWeak)
			{
				SoundController.PlaySound(sounds.goblinShoot);
				Debug.Log ("fire weak bullet");
				if(facingUp)
				{
					spawnedWeakBullet = GameObject.Instantiate (weakBulletPrefab, new Vector3(transform.position.x + 0.43f, transform.position.y + 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 180))) as GameObject;
				}
				else if(facingDown)
				{
					spawnedWeakBullet = GameObject.Instantiate (weakBulletPrefab, new Vector3(transform.position.x - 0.43f, transform.position.y - 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
				}
				else if(facingLeft)
				{
					spawnedWeakBullet = GameObject.Instantiate (weakBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90))) as GameObject;
				}
				else if (facingRight)
				{
					spawnedWeakBullet = GameObject.Instantiate (weakBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
				}
				spawnedWeakBullet.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, -500));
				canSpawnWeak = false;
				StartCoroutine( reloadWeak());
			}
		}
		else if (spawnMediumBullet)
		{
			if(canSpawnMedium)
			{
				SoundController.PlaySound(sounds.goblinShoot);
				Debug.Log ("fire medium bullet");
				if(facingUp)
				{
					spawnedMediumBullet = GameObject.Instantiate (mediumBulletPrefab, new Vector3(transform.position.x + 0.43f, transform.position.y + 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 180))) as GameObject;
				}
				else if(facingDown)
				{
					spawnedMediumBullet = GameObject.Instantiate (mediumBulletPrefab, new Vector3(transform.position.x - 0.43f, transform.position.y - 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
				}
				else if(facingLeft)
				{
					spawnedMediumBullet = GameObject.Instantiate (mediumBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90))) as GameObject;
				}
				else if (facingRight)
				{
					spawnedMediumBullet = GameObject.Instantiate (mediumBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
				}
				spawnedMediumBullet.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, -600));
				canSpawnMedium = false;
				StartCoroutine( reloadMedium());
			}
		}
		else if (spawnStrongBullet)
		{
			if(canSpawnStrong)
			{
				SoundController.PlaySound(sounds.goblinShoot);
				Debug.Log ("fire strong bullet");
				if(facingUp)
				{
					spawnedStrongBullet = GameObject.Instantiate (strongBulletPrefab, new Vector3(transform.position.x + 0.43f, transform.position.y + 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 180))) as GameObject;
				}
				else if(facingDown)
				{
					spawnedStrongBullet = GameObject.Instantiate (strongBulletPrefab, new Vector3(transform.position.x - 0.43f, transform.position.y - 0.72f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
				}
				else if(facingLeft)
				{
					spawnedStrongBullet = GameObject.Instantiate (strongBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90))) as GameObject;
				}
				else if (facingRight)
				{
					spawnedStrongBullet = GameObject.Instantiate (strongBulletPrefab, new Vector3(transform.position.x - 0f, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
				}
				spawnedStrongBullet.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, -700));
				canSpawnStrong = false;
				StartCoroutine( reloadStrong());
			}
		}
	}

	IEnumerator reloadWeak()
	{
		yield return new WaitForSeconds(0.7f);
		canSpawnWeak = true;
	}

	IEnumerator reloadMedium()
	{
		yield return new WaitForSeconds (0.7f);
		canSpawnMedium = true;
	}

	IEnumerator reloadStrong()
	{
		yield return new WaitForSeconds (0.7f);
		canSpawnStrong = true;
	}
}
