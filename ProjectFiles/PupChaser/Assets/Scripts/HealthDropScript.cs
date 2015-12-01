using UnityEngine;
using System.Collections;

public class HealthDropScript : MonoBehaviour {
    public Rigidbody2D rBody;
    public int random;
    public float counter;
    public Vector2 dir;
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            Destroy(gameObject);
        }
    }
    

    void Start ()
    {
        rBody = GetComponent<Rigidbody2D>();
        dir = new Vector2(Random.Range(-10,10), Random.Range(-10, 10));
       
        rBody.AddForce(dir * 10);
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter += Time.deltaTime;

        if (counter >= 20)
        {
            Destroy(gameObject);
        }

	}
}
