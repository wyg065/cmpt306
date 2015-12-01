using UnityEngine;
using System.Collections;
using Pathfinding;

public class enemyControllerspider : MonoBehaviour {

	public PlayerController myScript;
	public Transform target;
	public GameObject player;
	
	public float updateRate = 1.0f;
	
	private Seeker seeker;
	private Rigidbody2D rb;
	
	public Path path;
	
	public float speed = 100.0f;
	public ForceMode2D fMode;

	public bool alreadysaw ; 

	Dplayer dd ; 
	
	[HideInInspector]
	public bool pathIsEnded = false;
	
	public float nextWaypoinyDistance = 1.2f;
	
	private int currentWaypoint = 0;
	// Use this for initialization
	void Start () {
		alreadysaw = true; 
		dd = GetComponentInChildren<Dplayer> ();
		myScript = FindObjectOfType<PlayerController>();
		target = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform;
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();
		
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

	// Update is called once per frame
	void FixedUpdate () {

		if ((dd.inrange == true)||(alreadysaw == true))
		{
			alreadysaw = true ;
		//if (Dplayer2.inrange == true) {
			if (path == null)
				return;
		
			if (currentWaypoint >= path.vectorPath.Count) {
				if (pathIsEnded)
					return;
				pathIsEnded = true;
				return;
			}
			pathIsEnded = false;
		
			Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
			dir *= speed * Time.fixedDeltaTime;
		
			rb.AddForce (dir, fMode);
		
			if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < nextWaypoinyDistance) {
				currentWaypoint++;
				return;
			}
		}
	}
}
