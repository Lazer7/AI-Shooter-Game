using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    int count;
    public Sprite bulletSprite;
    public GameObject Enemy;
    public Queue<Direction> playerMovement;
    // Use this for initialization
    float bulletReload;
    bool canShoot;
	void Start () {

        count = 0;
        playerMovement = new Queue<Direction>();
        bulletReload = 0.5f;
        canShoot = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (bulletReload <= 0)
        {
            GameObject EnemyClone = GameObject.Instantiate(Enemy);
            EnemyClone.name = "Enemy";
            bulletReload = 0.5f;
            canShoot = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
           // 
            transform.Translate(0f, .3f, 0f);
            updateQueue(Direction.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
           //
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


        if (Input.GetKey(KeyCode.W)&& canShoot)
        {
            createBullet(0, 1200, 0, 0);

        }
        else if (Input.GetKey(KeyCode.S)&&canShoot)
        {
            createBullet(0, -1200, 0, 180);
        }
        else if (Input.GetKey(KeyCode.D)&& canShoot)
        {
             createBullet(1200, 0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.A)&& canShoot)
        {
            createBullet(-1200, 0, 0, 270);
        }
        
        bulletReload -= Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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
        GameObject bullet = new GameObject("Bullet");
        bullet.transform.localScale += new Vector3(5f, 10f, 0f);
        bullet.AddComponent<SpriteRenderer>();
        bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        bullet.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        bullet.AddComponent<Rigidbody2D>();
        bullet.transform.Rotate(0, 0, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y));
        bullet.GetComponent<Rigidbody2D>().gravityScale =0;
        bullet.AddComponent<BoxCollider2D>();
        canShoot = false;
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

}




