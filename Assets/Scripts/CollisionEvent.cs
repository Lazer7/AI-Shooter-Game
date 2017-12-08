using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Made by Jimmy Chao (Lazer)
/// 012677182
/// CECS 451
/// </summary>
public class CollisionEvent : MonoBehaviour {
    //These are bullet collision events
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the colliding object is a bullet
        if (collision.gameObject.name == "Bullet")
        {
            //Destroy the bullet object
            Destroy(collision.collider.gameObject);
            //if it is a enemy destroy it
            if (this.gameObject.name == "Enemy" || this.gameObject.name=="AStarEnemy")
            {
                Destroy(this.gameObject);
            }
        }
    }

}
