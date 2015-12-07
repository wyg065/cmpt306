using UnityEngine;
using System.Collections;
using Pathfinding;


public class GoblinController : MonoBehaviour {
	
	public PlayerController playerController;
	public GoblinAI goblin;


	//What the goblin enemy is walking towards
	public Transform target;

	public Transform killAreaLocation;
	
	public Transform player;


	//not sure why this variable was in the original enemyController
	//public GameObject playerPosition;
	
	public float updateRate = 1.0f;
	
	private Seeker seeker;
	//private Rigidbody2D rb; removed this for ease of reading code.
	
	public Path path;
	
	public float speed = 5000.0f;
	public ForceMode2D fMode;
	
	[HideInInspector]
	public bool pathIsEnded = false;
	
	public float nextWaypoinyDistance = 1.2f;
	
	private int currentWaypoint = 0;


	//private GameObject t
	public GameObject randomLocation;

	//location decision variables
	public bool followingPlayer;
	public bool retreating;
	public bool randomlyWalking;
	public bool movingToKillArea;

	//drob health
	public GameObject heartPrefab;
	public int chanceOfDropHeart;


	//health bar
	public GameObject healthBar;
	private GameObject goblinHealthBar;


	//kill goblin stuff
	//[HideInInspector]
	public float maxGoblinHealth;
	public float currentGoblinHealth;


	// Use this for initialization
	void Start ()
	{
		maxGoblinHealth = 5;
		currentGoblinHealth = 5;
		chanceOfDropHeart = Random.Range(1, 100);
		playerController = FindObjectOfType<PlayerController>();
		goblin = FindObjectOfType<GoblinAI> ();

		player = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;

		target = player;

		randomLocation = new GameObject ();

		seeker = GetComponent<Seeker>();
		//rb = GetComponent<Rigidbody2D>();
		
		if (target == null)
		{
			print("no target.");
			return;
		}

		goblinHealthBar = (GameObject)Instantiate (healthBar, new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z), Quaternion.identity);
		updateHealthBar ();

		seeker.StartPath(transform.position, target.position, onPathComplete);
		
		StartCoroutine(UpdatePath());
	}
	
	IEnumerator UpdatePath()
	{
		seeker.StartPath(transform.position, target.position, onPathComplete);
		
		yield return new WaitForSeconds(1f/updateRate);
		StartCoroutine(UpdatePath());
	}

	void updateHealthBar()
	{
		float barSize = (currentGoblinHealth / maxGoblinHealth) * 150;
		Debug.Log ("bar size: " + barSize);
		goblinHealthBar.transform.localScale = new Vector3(barSize, 3, 0);
	}
	
	public void onPathComplete(Path p)
	{
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.name == "Slice(Clone)" || col.gameObject.name == "ChargeAttack(Clone)" || col.gameObject.name == "PlayerFireBall(Clone)" || col.gameObject.name == "ChargedFireBall(Clone)" || col.gameObject.name == "AreaAttackPrefab(Clone)")
		{
			Vector3 dir = (transform.position - playerController.charPosition).normalized;
            if (col.gameObject.name == "ChargedFireBall(Clone)")
            {
                dir *= speed * Time.fixedDeltaTime * 150f;
            }
            else
            {
                dir *= speed * Time.fixedDeltaTime * 120f;
            }

            GetComponent<Rigidbody2D>().AddForce(dir, fMode);

			if (col.gameObject.name == "Slice(Clone)")
			{
				SoundController.PlaySound(sounds.goblinHurt);
				currentGoblinHealth = currentGoblinHealth - 2;
				updateHealthBar();
				if (currentGoblinHealth <= 0)
				{
					killGoblin (true);
				}
			}
			else if (col.gameObject.name == "ChargeAttack(Clone)")
			{
				SoundController.PlaySound(sounds.goblinHurt);
				currentGoblinHealth = currentGoblinHealth -3;
				updateHealthBar();
				if (currentGoblinHealth <=0)
				{
					killGoblin (true);
				}
			}
            else if(col.gameObject.name == "PlayerFireBall(Clone)")
            {
				SoundController.PlaySound(sounds.goblinHurt);
				currentGoblinHealth = currentGoblinHealth -1;
				updateHealthBar();
				if(currentGoblinHealth <= 0)
                {
                    killGoblin(true);
                }
            }
            else if (col.gameObject.name == "ChargedFireBall(Clone)")
            {
                SoundController.PlaySound(sounds.goblinHurt);
                currentGoblinHealth = currentGoblinHealth - 1;
                updateHealthBar();
                if (currentGoblinHealth <= 0)
                {
                    killGoblin(true);
                }
            }
            else if (col.gameObject.name == "AreaAttackPrefab(Clone)")
            {
                SoundController.PlaySound(sounds.goblinHurt);
                currentGoblinHealth = currentGoblinHealth - 1;
                updateHealthBar();
                if (currentGoblinHealth <= 0)
                {
                    killGoblin(true);
                }
            }
        }
	}

	public void killGoblin(bool normalDeath)
	{	
		if(chanceOfDropHeart < 12)
		{
			GameObject spawnedHeart = GameObject.Instantiate(heartPrefab, transform.position, transform.rotation) as GameObject;
		}

		if (normalDeath) {
			SoundController.PlaySound (sounds.goblinDie);
		} else {
			SoundController.PlaySound (sounds.goblinExplode);
		}

		Destroy (randomLocation);
		Destroy (goblinHealthBar);
		Destroy(gameObject);
	}


	void Update()
	{
		goblinHealthBar.transform.position = new Vector3 (transform.position.x, transform.position.y + 1.1f, transform.position.z);

		float distFromPlayer = Vector2.Distance(playerController.transform.position, transform.position);
		if (distFromPlayer >= 55)
		{
			Destroy(goblinHealthBar);
			Destroy(randomLocation);
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (followingPlayer)
		{
			followPlayer ();
		}
		else if (retreating)
		{
			retreat();
		}
		else if (randomlyWalking)
		{
			randomWalk();
		}
		else if (movingToKillArea)
		{
			moveToKillArea();
		}
	}

	void followPlayer () {
		target = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;

		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		GetComponent<Rigidbody2D>().AddForce(dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}
	
	void retreat() {
		target = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;
		
		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		GetComponent<Rigidbody2D>().AddForce(-dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	void randomWalk()
	{	
		float range = 6;
		float x = Random.Range (transform.position.x-range, transform.position.x+range);
		float y = Random.Range (transform.position.y-range, transform.position.y+range);
		
		randomLocation.transform.position = new Vector3 (x,y,0);
		target = randomLocation.transform;

		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		GetComponent<Rigidbody2D>().AddForce(dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	void moveToKillArea()
	{
		target = killAreaLocation;

		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		GetComponent<Rigidbody2D>().AddForce(dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}
