using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Made by Jimmy Chao (Lazer)
/// 012677182
/// CECS 451
/// 
/// AStarEnemy Script moves enemy by searching throgh the best path 
/// to get to player 
/// </summary>
public class AStarEnemy : MonoBehaviour
{
    //Place holders for gameObject Position
    float x;
    float y;
    // Update is called once per frame
    void Update()
    {
        //Get's the Player directional keystrokes saved in a queue
        GameObject player = GameObject.Find("PlayerObject");
        Queue<Direction> playerMovement = player.GetComponent<Player>().playerMovement;
        while (playerMovement.Count != 0)
        {
            //Look through the map of keys used to find best path to player
            switch (playerMovement.Peek())
            {
                //checks the direction of next node in the queue
                case Direction.up:
                    move(player.transform.position, Direction.up);
                    playerMovement.Dequeue();
                    break;
                case Direction.down:
                    move(player.transform.position, Direction.down);
                    playerMovement.Dequeue();
                    break;
                case Direction.left:
                    move(player.transform.position, Direction.left);
                    playerMovement.Dequeue();
                    break;
                case Direction.right:
                    move(player.transform.position, Direction.right);
                    playerMovement.Dequeue();
                    break;
            }
        }
        x = player.transform.position.x;
        y = player.transform.position.y;
    }
    //Checks if AStarEnemy has hit a wall
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if A star hits a wall ride up or down it
        if (collision.gameObject.name.Contains("Wall") && (collision.gameObject.name.Contains("3") || collision.gameObject.name.Contains("2") || collision.gameObject.name.Contains("1")))
        {
            if (y > transform.position.y)
            {
                transform.Translate(0f, 0.5f, 0f);
            }
            else { transform.Translate(0f, -0.5f, 0f); }
        }
        if (collision.gameObject.name.Contains("Enemy"))
        {
            transform.Translate(0f, 0.9f, 0f);
        }
    }
    //MOVE the AStarEnemy according to the player direction
    private void move(Vector3 playerposition, Direction direction)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
            transform.Translate(0, 0.05f, 0);
        }
        if (playerposition.y < transform.position.y)
        {
            transform.Translate(0, -0.05f, 0);
        }
    }

}
