using UnityEngine;
using System.Collections;

public class SpiderDecisionTree : MonoBehaviour {

	private enemyControllerspider ec  ; 
	private shootweb sw  ;
	private Animator anim ; 
	private shootweb3 sw3 ; 



	// Use this for initialization
	void Start () {
	
		ec = GetComponent<enemyControllerspider>(); 
		sw = GetComponent<shootweb>();
		anim = GetComponent<Animator> ();
		sw3 = GetComponent<shootweb3> ();

		int a = Random.Range (1 , 7);    

		if ((a == 1) || (a == 4)) {
		
			rapidattack ();

		} else if ((a == 2) || (a == 5)) {

			shootweb (); 

		} else if ((a == 3) || (a == 6)) {

			bothattacks ();
		} else if (a == 7) {
			shootweb3() ; 
		}
	}

	void rapidattack ()
	{
			ec.enabled = true;
			anim.SetBool ("Moving", false);
	}

	void shootweb() 
	{
		sw.enabled = true; 
	}

	void bothattacks() 
	{
		ec.enabled = true; 
		sw.enabled = true; 
	}

	void shootweb3()
	{
		sw3.enabled = true; 
		transform.localScale += new Vector3(5, 5, 0);

	}


	// Update is called once per frame
	void Update () {
	
		if (Dplayer.otherspiders == true) {
			ec.enabled = true; 
		} else if (Dplayer.otherber == true) {

			sw.enabled = true; 
			ec.enabled = false; 
		}
		else if (Dplayer.othergoblin == true)
		{
			sw.enabled = true; 
			ec.enabled = false; 
		}

	}

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.gameObject.name == "Slice(Clone)") {

			Destroy (gameObject) ; 
		}
        if (other.gameObject.name == "ChargeAttack(Clone)")
        {

            Destroy(gameObject);
        }


    }
}
