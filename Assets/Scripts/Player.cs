using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    int count;

    public Queue<Direction> playerMovement;
	// Use this for initialization
    
	void Start () {
        count = 0;
        playerMovement = new Queue<Direction>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
           // createBullet(0, -100, 0, 180);
            transform.Translate(0f, .3f, 0f);
            updateQueue(Direction.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
           // createBullet(0, -100, 0, 180);
            transform.Translate(0f, -.3f, 0f);
            updateQueue(Direction.down);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
           // createBullet(100, 0, 0, 90);
            transform.Translate(.3f, 0f, 0f);
            updateQueue(Direction.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //createBullet(-100, 0, 0, 270);
            transform.Translate(-.3f, 0f, 0f);
            updateQueue(Direction.left);
        }

    }
    void OnCollision(Collision collision)
    {
        Debug.Log("collision");
    }


    void updateQueue(Direction currentPlayerMovement)
    {
        if (playerMovement.Count == 50)
        {
            playerMovement.Dequeue();
        }
        playerMovement.Enqueue(currentPlayerMovement);
    }
    void createBullet(float x, float y , float z, int rotation)
    {
        GameObject bullet;
        bullet = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        bullet.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        bullet.AddComponent<Rigidbody>();
        bullet.transform.Rotate(0, 0, rotation);
        bullet.GetComponent<CapsuleCollider>().enabled = false;
        bullet.GetComponent<Rigidbody>().useGravity = false;
        bullet.GetComponent<Rigidbody>().AddForce(x,y,z);
    }

}




