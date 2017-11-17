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
        Queue<Direction> playerMovement = player.GetComponent<Player>().playerMovement;
        while(playerMovement != null)
        {
            switch (playerMovement.Peek()) {
                case Direction.up:
                    this.transform.Translate(0f, 1f, 0f);
                    playerMovement.Dequeue();
                    break;
                case Direction.down:
                    this.transform.Translate(0f, -1f, 0f);
                    playerMovement.Dequeue();
                    break;
                case Direction.left:
                    this.transform.Translate(-1f, 0f, 0f);
                    playerMovement.Dequeue();
                    break;
                case Direction.right:
                    this.transform.Translate(1f, 0f, 0f);
                    playerMovement.Dequeue();
                    break;



            }

        }
       


	}
}
