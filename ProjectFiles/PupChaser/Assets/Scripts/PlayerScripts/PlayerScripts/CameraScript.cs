using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //Script of player to follow
    public PlayerController Player;
	
	public GUIStyle progress_empty;
	public GUIStyle progress_full;
	
	//current progress
	public float barDisplay;
	
	Vector2 pos = new Vector2(10,50);
	Vector2 size = new Vector2(250,50);
	
	public Texture2D emptyTex;
	public Texture2D fullTex;

    // Use this for initialization
    void Start ()
    {
		//Get object to follow
		Player = FindObjectOfType<PlayerController> ();

	}

	void OnGUI()
	{
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y), emptyTex, progress_empty);
		
		GUI.Box(new Rect(pos.x, pos.y, size.x, size.y), fullTex, progress_full);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
		
		GUI.EndGroup();
		GUI.EndGroup();
	}
    // Update is called once per frame
    void Update()
    {
		barDisplay = Time.time*0.05f;
        //Move camera with global character position variable and sit high up on layer -10
        //transform.position =  new Vector3 (Player.charPosition.x, Player.charPosition.y, -10);

		//iTween.MoveUpdate(gameObject,new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z), 1.75f);
    }
	 void FixedUpdate() {
		iTween.MoveUpdate(gameObject,new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z), 1.75f);
	}
}
