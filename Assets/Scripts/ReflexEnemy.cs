using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Made by Jimmy Chao (Lazer)
/// 012677182
/// CECS 451
/// </summary>
public class ReflexEnemy : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //find gameObject
        GameObject player = GameObject.Find("PlayerObject");
        //move the game object to player position
        Vector3 playerposition = player.transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //move based on player position
        if (playerposition.x > transform.position.x)
        {
            transform.Translate(0.05f, 0, 0);
        }
        if (playerposition.x < transform.position.x)
        {
            transform.Translate(-0.05f, 0, 0);
        }

        if (playerposition.y > transform.position.y)
        {
            transform.Translate(0,0.05f, 0);
        }
        if (playerposition.y < transform.position.y)
        {
            transform.Translate(0,-0.05f, 0);
        }
    }
}
