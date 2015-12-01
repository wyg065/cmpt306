using UnityEngine;
using System.Collections;

public class GoblinAI : MonoBehaviour {

	//Other game components
	PlayerController player;
	GoblinController goblinController;
	ZombieAnimation goblinAnimation;
	SpawnGoblinBullet spawnGoblinBullet;

	//decision making
	public float normalSpeed;

	//threat zone stuff
	private float distEnemyFromPlayer;
	public float threatZoneRadius;

	//spawn location stuff
	private Vector2 originalSpawn;
	private float distEnemyFromSpawn;
	public float killAreaRadius;

	//reset target in GoblinController stuff
	private Transform killArea;

	//kamiKazi stuff
	private bool kamiKaziEngaged;
	public int oddsOfKamiKazi;
	private float explosionDistance;
	public float explosionDistanceThreshold;
	public float kamiKaziSpeed;
	private bool canKillGoblin;
	private bool playDetonateAnim;
	private bool kamiKaziHasBeenInRange;
	public GameObject explosionColliderPrefab;
	public GameObject explosionCollider;
	public bool explosionColliderCreated;

	//friends stuff
	public float friendsThreshold;
	private float distBetweenFriends;

	//delegate
	delegate void myDelegate();
	myDelegate enemyAction;

	public bool destroyRandomLocationGameObject;

	//update timer stuff.
	private float aiUpdateTimer;
	private float aiUpdateInterval = 0.6f;

	// Use this for initialization
	void Start ()
	{
		originalSpawn = transform.position;
		killArea = transform;
		oddsOfKamiKazi++;
		canKillGoblin = false;
		playDetonateAnim = false;
		kamiKaziHasBeenInRange = false;
		explosionColliderCreated = false;

		player = FindObjectOfType<PlayerController> ();
		goblinController = FindObjectOfType<GoblinController> ();
		goblinAnimation = FindObjectOfType<ZombieAnimation> ();
		spawnGoblinBullet = FindObjectOfType < SpawnGoblinBullet> ();

		goblinController.killAreaLocation = killArea;

		goblinController.followingPlayer = false;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;

		enemyAction = ThreatZone;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//updates the AI less frequently.
		//DO NOT CHANGE
		//Drastically reduces lag
		aiUpdateTimer -= Time.fixedDeltaTime;
		if (aiUpdateTimer < 0)
		{
			aiUpdateTimer = aiUpdateInterval;
			if (kamiKaziEngaged)
			{
				if (kamiKaziInRange () || kamiKaziHasBeenInRange)
				{
					detonate ();
				}
				else
				{
					enemyAction = kamiKazi;
				}
			}
			else
			{
				Debug.Log("Execute goblin AI Loop");
				kamiKaziEngaged = false;
				goblinController.speed = normalSpeed;
				spawnGoblinBullet.spawnWeakBullet = false;
				spawnGoblinBullet.spawnMediumBullet = false;
				spawnGoblinBullet.spawnStrongBullet = false;
				enemyAction ();
			}
		}
		else if (kamiKaziEngaged)
		{
			if (kamiKaziInRange () || kamiKaziHasBeenInRange)
			{
				detonate ();
			}
			else
			{
				enemyAction = kamiKazi;
			}
		}
	
	}


	//Decision Functions
	private void ThreatZone()
	{
		if (playerInThreatZone())
		{
			Debug.Log ("Player in threat zone");
			enemyAction = HPLow;
		}
		else
		{
			Debug.Log("Player not in threat zone");
			enemyAction = KillArea;
		}
	}

	private void KillArea()
	{
		if (outsideKillArea())
		{
			Debug.Log("Enemy has moved outside of kill area");
			enemyAction = moveToKillArea;
		}
		else
		{
			Debug.Log ("Enemy is inside kill area");
			enemyAction = PickRandomActivity;
		}
	}

	private void PickRandomActivity()
	{
		if (kamiKaziModeSelector() == 1)
		{
			Debug.Log("Engage KamiKazi Mode");
			enemyAction = kamiKazi;
		}
		else
		{
			Debug.Log("Enemy fool around");
			enemyAction = foolAround;
		}
	}


	private void HPLow()
	{
		if (goblinController.goblinDamage <= 2)
		{
			Debug.Log("HP is low");
			enemyAction = FriendsNear;
		}
		else
		{
			Debug.Log("Goblin Enemy is healthy");
			enemyAction = weakAttack;
		}
	}

	private void FriendsNear()
	{
		if (friendsAreNear ())
		{
			Debug.Log("Friends are near");
			int getWeapon = randomWeaponSelection();
			if(getWeapon == 1)
			{
				enemyAction = weakAttack;
			}
			else if (getWeapon == 2)
			{
				enemyAction = mediumAttack;
			}
			else if (getWeapon == 3)
			{
				enemyAction = strongAttack;
			}
		}
		else
		{
			Debug.Log("Friends are not near");
			enemyAction = runAway;
		}
	}


	//Action Functions
	private void moveToKillArea()
	{

		Debug.Log("Moving to kill area");
		goblinController.followingPlayer = false;
		goblinController.movingToKillArea = true;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;
		enemyAction = ThreatZone;
	}

	private void kamiKazi()
	{
		Debug.Log ("Engage Kami Kazi Mode");
		kamiKaziEngaged = true;
		goblinController.followingPlayer = true;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;
		goblinController.speed = kamiKaziSpeed;
		//detonate here somehow
		enemyAction = ThreatZone;
	}
	
	private void foolAround()
	{
		Debug.Log ("Fool around");
		goblinController.followingPlayer = false;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = true;
		enemyAction = ThreatZone;
	}


	private void weakAttack()
	{
		Debug.Log ("Weak Attack");

		goblinController.followingPlayer = true;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;

		spawnGoblinBullet.spawnWeakBullet = true;
		spawnGoblinBullet.spawnMediumBullet = false;
		spawnGoblinBullet.spawnStrongBullet = false;

		enemyAction = ThreatZone;

	}

	private void mediumAttack()
	{
		Debug.Log ("Medium Attack");

		goblinController.followingPlayer = true;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;

		spawnGoblinBullet.spawnWeakBullet = false;
		spawnGoblinBullet.spawnMediumBullet = true;
		spawnGoblinBullet.spawnStrongBullet = false;
		enemyAction = ThreatZone;

	}

	private void strongAttack()
	{
		Debug.Log ("Strong Attack");

		goblinController.followingPlayer = true;
		goblinController.movingToKillArea = false;
		goblinController.retreating = false;
		goblinController.randomlyWalking = false;

		spawnGoblinBullet.spawnWeakBullet = false;
		spawnGoblinBullet.spawnMediumBullet = false;
		spawnGoblinBullet.spawnStrongBullet = true;

		enemyAction = ThreatZone;
	}

	private void runAway()
	{
		Debug.Log ("Run Away");

		goblinController.followingPlayer = false;
		goblinController.movingToKillArea = false;
		goblinController.retreating = true;
		goblinController.randomlyWalking = false;

		enemyAction = ThreatZone;
	}

	//Other/Helper Functions
	private bool playerInThreatZone()
	{
		distEnemyFromPlayer = Vector2.Distance (player.charPosition, transform.position);
		if (distEnemyFromPlayer <= threatZoneRadius)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private bool outsideKillArea()
	{
		distEnemyFromSpawn = Vector2.Distance (originalSpawn, transform.position);
		if (distEnemyFromSpawn > killAreaRadius)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator runawayBuffer()
	{
		yield return new WaitForSeconds (3f);
		goblinController.enabled = true;
	}

	private bool friendsAreNear()
	{
		distBetweenFriends = Vector2.Distance (FindClosestEnemy().transform.position, transform.position);
		if (distBetweenFriends <= friendsThreshold)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	private int kamiKaziModeSelector()
	{
		int generatedNum = Random.Range (1, oddsOfKamiKazi);
		return generatedNum;
	}

	private int randomWeaponSelection()
	{
		int generatedNum = Random.Range (1, 4);
		Debug.Log ("random num = " + generatedNum);
		return generatedNum;
	}

	private bool kamiKaziInRange()
	{
		explosionDistance = Vector2.Distance (player.charPosition, transform.position);
		if (explosionDistance < explosionDistanceThreshold)
		{
			kamiKaziHasBeenInRange = true;
			return true;
		}
		else
		{
			return false;
		}
	}

	private void detonate()
	{
		Debug.Log ("detonate");
		goblinController.speed = 0;
		GetComponent<SpriteRenderer>().color = Color.red;
		StartCoroutine (detonateLag ());
		if (playDetonateAnim)
		{
			GetComponent<SpriteRenderer>().color = Color.white;
			goblinAnimation.timeToDetonate = true;
			if(!explosionColliderCreated)
			{
				explosionCollider = GameObject.Instantiate (explosionColliderPrefab, transform.position, transform.rotation) as GameObject;
				explosionColliderCreated = true;
			}
			StartCoroutine (waitToKill ());
		}
		if (canKillGoblin)
		{
			goblinController.killGoblin ();
		}
	}

	IEnumerator detonateLag()
	{
		yield return new WaitForSeconds (1f);
		playDetonateAnim = true;
	}

	IEnumerator waitToKill()
	{
		yield return new WaitForSeconds (1f);
		canKillGoblin = true;
	}

	public GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("goblin");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance && go != this) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}
