using UnityEngine;
using System.Collections;
using Pathfinding;


public class PupController : MonoBehaviour {

	//for accessing player public vars
	public PlayerController myScript;
	
	//players or targets transform
	public Transform target;
	
	//how often the path to target is updated
	public float updateRate = 1.0f;
	
	//seeker object for path finding
	private Seeker seeker;
	//reference to this rigid body
	private Rigidbody2D rb;
	
	//path to follow
	public Path path;
	
	//speed for enemy
	public float speed = 100.0f;
	public ForceMode2D fMode;
	
	[HideInInspector]
	//bool for if path ended
	public bool pathIsEnded = false;
	
	//distance between nodes that form path
	public float nextWaypoinyDistance = 1.2f;
	
	//node you are currently at
	private int currentWaypoint = 0;
	
	// Use this for initialization
	void Start () {
		//assign varibles
		myScript = FindObjectOfType<PlayerController>();
		target = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		
		//if not target return null
		if (target == null)
		{
			print("no target.");
			return;
		}
		//starts the seeker down the patht
		seeker.StartPath(transform.position, target.position, onPathComplete);
		
		//calls first time to update a new path
		StartCoroutine(UpdatePath());
	}
	
	//starts the seeker on a new path every updaterate (1 sec)
	IEnumerator UpdatePath()
	{
		seeker.StartPath(transform.position, target.position, onPathComplete);
		
		yield return new WaitForSeconds(1f/updateRate);
		StartCoroutine(UpdatePath());
	}
	
	//gets called if seeker reaches end of path
	public void onPathComplete(Path p)
	{
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//exits if path is null
		if (path == null)
			return;
		
		//sets pathisended to true, if your on the last node of the path
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		
		//sets up force to add to rigidbody in direction of next node on path
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		//adds above force to rigidbody
		rb.AddForce(dir, fMode);
		
		//moves to next node
		if (Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}