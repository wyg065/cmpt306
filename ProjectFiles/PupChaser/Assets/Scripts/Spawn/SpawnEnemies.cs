using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject SnakePrefab;
    public GameObject GoblinPrefab;
    public GameObject SpiderPrefab;
    public GameObject BerserkerPrefab;

    public float counter;
    public float spawnSpeed;
    public int difficultyMax;
    public int enemiesInList;
    public int currentDifficulty;
    public List<GameObject> enemyList;
    public float distFromPlayer;

    public int berserkerCount;
    public int goblinCount;
    public int snakeCount;
    public int spiderCount;
    public PlayerController Player;

    public bool playerInZone;
    public int spawnRadius;
    public int stopSpawnRadius;
    public bool stopSpawning;

    public float SpawnRate = 0.05F;
    public float nextspawn = 0.05F;
    public float checkList;

    // Use this for initialization
    void Start()
    {
        enemyList = new List<GameObject>();
        Player = FindObjectOfType<PlayerController>();
        spawnRadius = 50;
        stopSpawnRadius = 25;
        currentDifficulty = 0;
    }

    private void checkZone()
    {
        distFromPlayer = Vector2.Distance(Player.charPosition, transform.position);
        if (distFromPlayer <= spawnRadius)
        {
            playerInZone = true;
        }
        else
        {
            playerInZone = false;
        }
        if(distFromPlayer <= stopSpawnRadius)
        {
            stopSpawning = true;
        }
        else
        {
            stopSpawning = false;
        }
    }

    void handleList()
    {
        currentDifficulty = 0;
        goblinCount = 0;
        berserkerCount = 0;
        snakeCount = 0;
        spiderCount = 0;

        for (int i = 0; i < enemiesInList; i++)
        {
            if (enemyList[i].gameObject)
            {


                if (enemyList[i].gameObject.name == "Berserker(Clone)")
                {
                    berserkerCount++;
                }
                else if (enemyList[i].gameObject.tag == "goblin")
                {
                    goblinCount++;
                }
                else if (enemyList[i].gameObject.tag == "spider")
                {
                    spiderCount++;
                }
                else if (enemyList[i].gameObject.tag == "firesnake")
                {
                    snakeCount++;
                }
            }
            else
            {
                enemyList.RemoveAt(i);
            }
        }
        currentDifficulty = (berserkerCount * 3) + (goblinCount * 2) + (spiderCount) + (snakeCount * 2);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        checkList += Time.deltaTime;
        int a = Random.Range(1, 100);

        enemiesInList = enemyList.Count;

        if (checkList > 6)
        {
            handleList();
            checkZone();
            checkList = 0;
        }

        if (counter > spawnSpeed && currentDifficulty <= difficultyMax && playerInZone && !stopSpawning)
        {
            counter = 0;
            if (a <= 25)
            {

                GameObject spawnedenemy = GameObject.Instantiate(SnakePrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
                currentDifficulty += 2;

            }
            else if (a <= 50 && a > 25)
            {

                GameObject spawnedenemy = GameObject.Instantiate(GoblinPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
                currentDifficulty += 2;

            }
            else if (a <= 85 && a > 50)
            {

                GameObject spawnedenemy = GameObject.Instantiate(SpiderPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
                currentDifficulty += 1;

            }
            else if (a <= 100 && a > 85)
            {

                GameObject spawnedenemy = GameObject.Instantiate(BerserkerPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
                currentDifficulty += 3;
            }
        }
    }
}
