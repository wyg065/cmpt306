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


	//kill goblin stuff
	//[HideInInspector]
	public int goblinDamage;


	// Use this for initialization
	void Start () {
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
		if(col.gameObject.name == "Slice(Clone)" || col.gameObject.name == "ChargeAttack(Clone)" || col.gameObject.name == "PlayerFireBall(Clone)")
		{
			Vector3 dir = (transform.position - playerController.charPosition).normalized;
			dir *= speed * Time.fixedDeltaTime * 120f;
			
			GetComponent<Rigidbody2D>().AddForce(dir, fMode);

			if (col.gameObject.name == "Slice(Clone)")
			{
				goblinDamage = goblinDamage - 2;
				if (goblinDamage <= 0)
				{
					killGoblin ();
				}
			}else if (col.gameObject.name == "ChargeAttack(Clone)")
			{
				goblinDamage = goblinDamage -3;
				if (goblinDamage <=0)
				{
					killGoblin ();
				}
			}
            else if(col.gameObject.name == "PlayerFireBall(Clone)")
            {
                goblinDamage--;
                if(goblinDamage <= 0)
                {
                    killGoblin();
                }
            }
		}
	}

	public void killGoblin()
	{
		Destroy (randomLocation);
		Destroy(gameObject);
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
