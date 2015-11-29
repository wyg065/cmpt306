using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

	public GameObject SnakePrefab; 
	public GameObject GoblinPrefab; 
	public GameObject SpiderPrefab;
	public GameObject BerserkerPrefab; 

    public int difficultyMax;
    public int enemiesInList;
    public int currentDifficulty;
    public List<GameObject> enemyList;

    public int berserkerCount;
    public int goblinCount;
    public int snakeCount;
    public int spiderCount;

    public float SpawnRate = 0.05F; 
	public float nextspawn = 0.05F;
    public float checkList;

    // Use this for initialization
    void Start ()
    {
        enemyList = new List<GameObject>();
        currentDifficulty = 0;
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
	void Update ()
	{

		int a = Random.Range (1 , 18);
        enemiesInList = enemyList.Count;

        checkList += Time.deltaTime;

        if (checkList > 6)
        {
            handleList();
            checkList = 0;
        }

        if (Time.time > nextspawn && currentDifficulty <= difficultyMax) {
			
			nextspawn = Time.time + SpawnRate;
            
			if ((a == 1) || (a == 2) || (a == 3) || (a == 11)) {

				GameObject spawnedenemy = GameObject.Instantiate (SnakePrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
			
			} else if ((a == 4) || (a == 5) || (a == 6) || (a == 12)) {

                GameObject spawnedenemy = GameObject.Instantiate (GoblinPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);

            } else if ((a == 15) || (a == 16) || (a == 17) || (a == 7) || (a == 8) || (a == 13) || (a == 14)) {

                GameObject spawnedenemy = GameObject.Instantiate (SpiderPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
                currentDifficulty += 1;

            } else if ((a == 9) || (a == 10)) {

                GameObject spawnedenemy = GameObject.Instantiate (BerserkerPrefab, transform.position, transform.rotation) as GameObject;
                enemyList.Add(spawnedenemy);
            }
		}
	}
}
