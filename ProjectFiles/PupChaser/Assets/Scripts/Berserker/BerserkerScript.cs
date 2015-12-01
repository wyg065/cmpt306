using UnityEngine;
using System.Collections;
using Pathfinding;


public class BerserkerScript : MonoBehaviour
{
    //Stuff for A*
    public PlayerController myScript;
    public Transform target;
    private GameObject t;
    public GameObject player;
    public GameObject heartPrefab;

    public float distFromPlayer;
    public int i;
    public float updateRate = 1.0f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 100.0f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypoinyDistance = 1.2f;

    private int currentWaypoint = 0;

    //

    public PlayerController Player;
    public Animator anim;

    public float time;
    public float rand;
    public float chargeTime;
    public float chargePower;
    public float chargeLag;
    public int healthPoints;

    public bool playerInThreatZone;
    public float distEnemyFromPlayer;
    public float threatZoneRadius;
    float disEnemyFromPlayer;

    public Vector3 targetPlayer;
    public Vector3 chargePosition;

    delegate void MyDelagate();
    MyDelagate berserkerAction;



    //Function to handle collisions.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Slice(Clone)")
        {
            healthPoints--;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;

            rb.AddForce(dir, fMode);
        }
        if (other.gameObject.name == "ChargeAttack(Clone)")
        {
            healthPoints = healthPoints - 3;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 120000f;
            rb.AddForce(dir, fMode);
        }
        if(other.gameObject.name == "PlayerFireBall(Clone)")
        {
            healthPoints--;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 20000f;
            rb.AddForce(dir, fMode);
        }
    }

    IEnumerator UpdatePath()
    {
        seeker.StartPath(transform.position, target.position, onPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void onPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void checkThreatZone()
    {
        distEnemyFromPlayer = Vector2.Distance(Player.charPosition, transform.position);
        if (distEnemyFromPlayer <= threatZoneRadius)
        {
            playerInThreatZone = true;
        }
        else
        {
            playerInThreatZone = false;
        }
    }


    // Use this for initialization
    void Start()
    {

        rand = Random.Range(1.0f, 4.0f);

        Player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        t = new GameObject();
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().transform;
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, target.position, onPathComplete);

        StartCoroutine(UpdatePath());

        if (rand > 1)
        {
            berserkerAction = randomMove;
            GetComponent<SpriteRenderer>().color = Color.green;
            transform.localScale += new Vector3(10, 10, 0);
            threatZoneRadius = 7;
            speed = 300;
            chargeTime = 3;
            chargePower = 1000;
            chargeLag = 4;
            healthPoints = 10;
        }
        if (rand > 2 && rand < 3)
        {
            berserkerAction = moveToPlayer;
            GetComponent<SpriteRenderer>().color = Color.magenta;
            transform.localScale += new Vector3(1, 1, 0);
            threatZoneRadius = 5;
            speed = 500;
            chargeTime = 2;
            chargePower = 800;
            chargeLag = 1;
            healthPoints = 8;
        }
        if (rand > 3)
        {
            berserkerAction = moveToPlayer;
            GetComponent<SpriteRenderer>().color = Color.red;
            threatZoneRadius = 4;
            speed = 2000;
            chargeTime = 1;
            chargePower = 800;
            chargeLag = 1;
            healthPoints = 5;
        }

    }

    // Update is called once per frame
    void Update()
    {
        distFromPlayer = Vector2.Distance(Player.charPosition, transform.position);

        if(distFromPlayer >= 55)
        {
            Destroy(target);
            Destroy(this.gameObject);
        }

        if (healthPoints < 1)
        {
            i = Random.Range(1, 100);

            if(i > 33)
            {
                GameObject spawnedenemy = GameObject.Instantiate(heartPrefab, transform.position, transform.rotation) as GameObject;
            }

            Destroy(t);
            Destroy(gameObject);
        }
        berserkerAction();
    }

    public void moveToPlayer()
    {
        checkThreatZone();
        if (playerInThreatZone)
        {
            berserkerAction = charge;
        }
        if (healthPoints < 3 && rand > 2 && rand < 3)
        {
            threatZoneRadius = 10;
            berserkerAction = lowHealth;
        }


        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().transform;

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
        {
            currentWaypoint++;
            return;
        }

    }

    public void randomMove()
    {
        checkThreatZone();
        if (playerInThreatZone)
        {
            berserkerAction = charge;
        }

        float range = 6;
        float x = Random.Range(transform.position.x - range, transform.position.x + range);
        float y = Random.Range(transform.position.y - range, transform.position.y + range);
        t.transform.position = new Vector3(x, y, 0);
        target = t.transform;

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
        {
            currentWaypoint++;
            return;
        }


    }

    public void charge()
    {
        time += Time.deltaTime;
        if (time < chargeTime - 0.75f)
        {
            chargePosition = Player.transform.position - this.transform.position;
        }

        if (time > chargeTime - 0.75f)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (time > chargeTime)
        {
            if (rand > 1 && rand < 2)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (rand > 2 && rand < 3)
            {
                GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            if (rand > 3)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }

            rb.AddForce(chargePosition * chargePower);
            time = 0;
            berserkerAction = chargeStun;
        }
    }

    public void chargeStun()
    {
        time += Time.deltaTime;
        if (time > chargeLag)
        {
            time = 0;
            berserkerAction = moveToPlayer;
        }


    }

    public void lowHealth()
    {
        checkThreatZone();
        if (!playerInThreatZone)
        {
            berserkerAction = goBerserk;
        }
        if (playerInThreatZone)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().transform;

            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            Vector3 dir = -(path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= 7000 * Time.fixedDeltaTime;

            rb.AddForce(dir, fMode);

            if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
            {
                currentWaypoint++;
                return;
            }
        }
    }
    public void goBerserk()
    {      
            target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().transform;

            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= 10000 * Time.fixedDeltaTime;

            rb.AddForce(dir, fMode);

            if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypoinyDistance)
            {
                currentWaypoint++;
                return;
            }
    }
}
