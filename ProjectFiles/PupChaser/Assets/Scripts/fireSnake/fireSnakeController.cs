using UnityEngine;
using System.Collections;
using Pathfinding;

public class fireSnakeController : MonoBehaviour {

	private PlayerController playerScriptReference;
	private Transform target;
	public GameObject player;
	private Animator anim;
	public GameObject fireBall;
	public GameObject iceShard;
	public GameObject leaf;
	public GameObject lightning;
	public GameObject rock;

	public GameObject heartPrefab;

	public GameObject healthBar;

    public float updateRate = 1.0f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 100.0f;
    public ForceMode2D fMode;

	//variable to store the absolute value of goblin's y velocity
	private float y = 0;
	
	//variable to store the absolute value of goblin's x velocity
	private float x = 0;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypoinyDistance = 1.0f;

    private int currentWaypoint = 0;

	private float rateOfFire = 2.2f;
	private float fireTimer = 0.0f;
	//bool used to control rate of fire
	private bool canFire = false;
	//distance enemy has to be from player to attack
	private float threatDistance = 2.5f;

	private float aiUpdateTimer;
	private float aiUpdateInterval = 0.25f;

	private float origX = 0.0f;
	private float origY = 0.0f;

	private float health = 10;
	private float maxHealth = 10;

	private GameObject randomLocation;
	private GameObject spawnLocation;
	private GameObject snakeHealthBar;

	private int snakeType = 0;

	private bool keepMovingtoPlayer = false;
	private bool keepMovingRandom = false;
	private bool keepRetreating = false;
	private bool keepReturningToSpawn = false;

	// Use this for initialization
	void Start () {
		snakeType = Random.Range(0,5);
		if (snakeType == 0) {
			GetComponent<SpriteRenderer> ().color = new Color32(200,0,0,255);
			rateOfFire = 2.2f;
			speed = 7500.0f;
			maxHealth = 3;
		} else if (snakeType == 1) {
			GetComponent<SpriteRenderer> ().color = new Color32(0,76,153,255);
			rateOfFire = 2.8f;
			speed = 7500.0f;
			maxHealth = 3;
		} else if (snakeType == 2) {
			GetComponent<SpriteRenderer> ().color = new Color32(210,210,0,255);
			rateOfFire = 2.2f;
			speed = 10000.0f;
			maxHealth = 2;
		} else if (snakeType == 3) {
			GetComponent<SpriteRenderer> ().color = new Color32(0,170,0,255);
			rateOfFire = 2.2f;
			speed = 7500.0f;
			maxHealth = 3;
		} else {
			GetComponent<SpriteRenderer> ().color = new Color32(102,51,0,255);
			rateOfFire = 3.2f;
			speed = 4000.0f;
			maxHealth = 6;
		}

		health = maxHealth;
		fireTimer = rateOfFire;
		spawnLocation = new GameObject ();
		randomLocation = new GameObject ();
		origX = transform.position.x;
		origY = transform.position.y;
		aiUpdateTimer = aiUpdateInterval;

		playerScriptReference = FindObjectOfType<PlayerController>();

		target = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();

        if (target == null)
        {
            print("no target.");
            return;
        }

		//loads health bar, and gives reference tho that specific health bar a.k.a snakeHelathBar
		snakeHealthBar = (GameObject)Instantiate (healthBar, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
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
	
    public void onPathComplete(Path p)
    {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.name == "Slice(Clone)")
		{
			SoundController.PlaySound (sounds.snakeDie);
			Vector3 dir = (transform.position - playerScriptReference.charPosition).normalized;
			dir *= speed * Time.fixedDeltaTime * 120f;
			
			rb.AddForce(dir, fMode);
			health--;
			updateHealthBar ();
		}
		if(col.gameObject.name == "ChargeAttack(Clone)")
		{
			SoundController.PlaySound (sounds.snakeDie);
			Vector3 dir = (transform.position - playerScriptReference.charPosition).normalized;
			dir *= speed * Time.fixedDeltaTime * 180f;
			
			rb.AddForce(dir, fMode);
			health -=2;
			updateHealthBar ();
		}
		if(col.gameObject.name == "PlayerFireBall(Clone)")
		{
			SoundController.PlaySound (sounds.snakeDie);
			Vector3 dir = (transform.position - playerScriptReference.charPosition).normalized;
			dir *= speed * Time.fixedDeltaTime * 180f;
			
			rb.AddForce(dir, fMode);
			health--;
			updateHealthBar ();
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//future
	}

	void fire() {
		SoundController.PlaySound (sounds.snakeShoot);
		if (snakeType == 0) {
			Instantiate(fireBall, transform.position, Quaternion.identity);
		} else if (snakeType == 1) {
			Instantiate(iceShard, transform.position, Quaternion.identity);
		} else if (snakeType == 2) {
			Instantiate(lightning, transform.position, Quaternion.identity);
		} else if (snakeType == 3) {
			var obj = (GameObject)Instantiate(leaf, transform.position, Quaternion.identity);
			obj.GetComponent<leafController>().setTarget(gameObject);
		} else {
			Instantiate(rock, transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if ((Vector3.Distance(transform.position,target.position) >= threatDistance) && canFire && 
		Vector2.Distance (GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position, transform.position) < 7f) {
			fire();
			canFire = false;
		}
		if (health <= 0) {
			int i = Random.Range(1, 100);
			
			if(i > 0)
			{
				GameObject spawnedenemy = GameObject.Instantiate(heartPrefab, transform.position, transform.rotation) as GameObject;
			}
			Destroy(randomLocation);
			Destroy(spawnLocation);
			Destroy(snakeHealthBar);
			Destroy(gameObject);
		}
		//updates the AI less frequently.
		//DO NOT CHANGE
		//Drastically reduces lag
		aiUpdateTimer -= Time.fixedDeltaTime;
		if (aiUpdateTimer < 0) {
			aiUpdateTimer = aiUpdateInterval;
			aiLoop();
			updateMoveAnimation ();
		} else if (keepMovingtoPlayer) {
			moveToTarget();
		} else if (keepRetreating) {
			retreat();
		} else if (keepMovingRandom) {
			moveToRandom();
		} else if (keepReturningToSpawn) {
			returnToSpawn();
		}
    }

	void Update() {
		snakeHealthBar.transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
		fireTimer -= Time.deltaTime;
		if (fireTimer < 0) {
			canFire = true;
			fireTimer = rateOfFire;
		}
	}

	void updateHealthBar() {
		float barSize = (health / maxHealth) * 150;
		snakeHealthBar.transform.localScale = new Vector3(barSize, 3, 0);
	}


	void aiLoop() {
		keepMovingtoPlayer = false;
		keepMovingRandom = false;
		keepRetreating = false;
		keepReturningToSpawn = false;
		//if (inSpawnArea) {
		Vector3 playerPos = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position;
		Vector3 spawnPos = new Vector3 (origX, origY, 0);
		float playerDistance = Vector2.Distance (transform.position, playerPos);
		if (Vector2.Distance (transform.position, spawnPos) < 12f) { //if to far from spawn zone
			if(playerDistance < 9f) {
				// if able to see player
				if(playerDistance > 6f) { //if too far to shoot from player
					keepMovingtoPlayer = true;
					moveToTarget();
				} else {
					if(playerDistance < 5f) { //if to close to player
						if (health/maxHealth > .6f) { //if health is above 50%
							moveToTarget();
							keepMovingtoPlayer = true;
							if (canFire) {
								fire();
								canFire = false;
							}
						} else {
							//print ("retreating");
							keepRetreating = true;
							retreat();
						}
					} else {
						if (canFire) {
							fire();
							canFire = false;
						}
					}
				}
			} else {
				keepMovingRandom = true;
				moveToRandom(); //move to random spot within spoawn are
			}
		} else {
			if(playerDistance < 7f) {
				if (health/maxHealth > .3f) {
					keepMovingtoPlayer = true;
					moveToTarget();
					if (canFire) {
						fire();
						canFire = false;
					}
				} else {
					keepReturningToSpawn = true;
					returnToSpawn();
				}
			} else {
				keepReturningToSpawn = true;
				returnToSpawn();
			}
		}
	}
	

	void moveToTarget() {
		target.position = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position;
		
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
		
		rb.AddForce(dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	void moveToRandom() {
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
		
		rb.AddForce(dir, fMode);
		
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
		
		rb.AddForce(-dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	void returnToSpawn() {	
		float range = 1;
		float x = Random.Range (origX-range, origX+range);
		float y = Random.Range (origY-range, origY+range);
		
		spawnLocation.transform.position = new Vector3 (x,y,0);
		target = spawnLocation.transform;
		
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
		
		rb.AddForce(dir, fMode);
		
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}

	void updateMoveAnimation()
	{
		print("test");
		//the absolute value of the target's y velocity
		y = Mathf.Abs (rb.velocity.y);
		//the absolute value of the target's x velocity
		x = Mathf.Abs (rb.velocity.x);

		//because the target could be moving left, right, and up or down we need a way to decide
		//which animation to play. Therefore whichever is greater velocity, the animation for that
		//direction will be played.  This is the reasoning for finding the absolute value of x and y
		//velocity.
		//If y is greater than x, play y animation
		if (y > x)
		{
			//if y velocity is positive
			if (rb.velocity.y > 0)
			{
				//set the move up boolean value to true
				anim.SetBool("moveUp", true);
				//set all other values to false
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
			//if the y velocity is negative
			if (rb.velocity.y < 0)
			{
				//set the move down boolean value to true
				anim.SetBool("moveDown", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
		}
		//otherwise if x is less than y, play x animation.
		else
		{
			//if the x velocity is negative
			if (rb.velocity.x < 0)
			{
				//set the move left boolean value to true
				anim.SetBool("moveLeft", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveRight", false);
			}
			//if the x velocity is positive
			if (rb.velocity.x > 0)
			{
				//set the move right boolean value to true
				anim.SetBool("moveRight", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
			}
		}
	}
}
