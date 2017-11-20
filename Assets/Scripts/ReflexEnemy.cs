using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexEnemy : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject player = GameObject.Find("PlayerObject");
        Vector3 playerposition = player.transform.position;
        if (playerposition.x > transform.position.x)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else if (playerposition.x < transform.position.x)
        {
            transform.Translate(-0.1f, 0, 0);
        }

        if (playerposition.y > transform.position.y)
        {
            transform.Translate(0,0.1f, 0);
        }
        else if (playerposition.y < transform.position.y)
        {
            transform.Translate(0,-0.1f, 0);
        }
    }
}
