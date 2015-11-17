using UnityEngine;
using System.Collections;

public class BerserkerThreatScript : MonoBehaviour {

    public bool inVision;
    public BerserkerScript Berserker;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inVision = true;
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            inVision = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
        inVision = false;
        Berserker = FindObjectOfType<BerserkerScript>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = new Vector3(Berserker.transform.position.x, Berserker.transform.position.y, 0);
    }
}
