
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Made by Jimmy Chao (Lazer)
/// 012677182
/// CECS 451
/// </summary>
public class Player : MonoBehaviour
{
    //Get the bullet's animation
    public Sprite bulletSprite;
    //Get the Enemy Game Object
    public GameObject Enemy;
    //Get the A Star Enemy GameObject
    public GameObject AStarEnemy;
    //Get GameOver Screen Overlay
    public GameObject GameOverScreen;
    //Make Map of Direction Keys Pressed
    public Queue<Direction> playerMovement;
    //Reload time for bullets
    float bulletReload;
    //Reload time for enemies
    float enemyCreation;
    //Wait flag for shooting another bullet
    bool canShoot;
    //Tells if the game is over
    public bool gameOver;
    int level;
    //Make random colors
    System.Random random;
    //Set initial values to variables
    void Start()
    {
        playerMovement = new Queue<Direction>();
        bulletReload = 0.1f;
        enemyCreation = .5f;
        canShoot = true;
        random = new System.Random();
        gameOver = false;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            //This is for bullet reload, player can shoot a bullet every .1 sec
            if (bulletReload <= 0)
            {
                bulletReload = 0.1f;
                canShoot = true;
            }
            //This is to create an enemy after .5 seconds have passed
            if (enemyCreation <= 0)
            {
                //If 10 enemies have not been created yet make a normal enemy
                if (level != 10)
                {
                    //Create enemy object
                    GameObject EnemyClone = GameObject.Instantiate(Enemy);
                    EnemyClone.name = "Enemy";
                    //Sets the enemy position 3 scales away from player
                    float x = 0;
                    float y = 0;
                    do
                    {
                        x = (float)(random.Next(-25, 40));
                        y = (float)(random.Next(-15, 6));
                    } while (Mathf.Abs(x - this.transform.position.x) > 3 && Mathf.Abs(y - this.transform.position.y) > 3);
                    EnemyClone.transform.Translate(x, y, 0f);
                    //Make rigidbody and set gravity scale to 0
                    EnemyClone.GetComponent<SpriteRenderer>().color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                    Enemy.AddComponent<Rigidbody2D>();
                    Enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
                    enemyCreation = .5f;
                    level++;
                }
                //if 10 enemies have been createde make aqn A star enemy
                else
                {
                    //Instantiate the A star enemy
                    GameObject EnemyClone = GameObject.Instantiate(AStarEnemy);
                    EnemyClone.name = "AStarEnemy";
                    //Sets the enemy position 3 scales away from player
                    float x = 0;
                    float y = 0;
                    do
                    {
                        x = (float)(random.Next(-25, 40));
                        y = (float)(random.Next(-15, 6));
                    } while (Mathf.Abs(x - this.transform.position.x) > 3 && Mathf.Abs(y - this.transform.position.y) > 3);
                    enemyCreation = .5f;
                    EnemyClone.transform.Translate(x, y, 0f);
                    level = 0;
                }


            }
            //This is to move the player and save the direction they moved
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
            //This is to shoot the bullet in a certain direction (Diagnol Shooting is possible)
            if (Input.GetKey(KeyCode.W) && canShoot)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    createBullet(-1200, 1200, 0, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    createBullet(1200, 1200, 0, 0);
                }
                else
                {
                    createBullet(0, 1200, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.S) && canShoot)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    createBullet(-1200, -1200, 0, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    createBullet(1200, -1200, 0, 0);
                }
                else
                {
                    createBullet(0, -1200, 0, 180);
                }
            }
            else if (Input.GetKey(KeyCode.D) && canShoot)
            {
                createBullet(1200, 0, 0, 90);
            }
            else if (Input.GetKey(KeyCode.A) && canShoot)
            {
                createBullet(-1200, 0, 0, 270);
            }
            //countdown timer for enemy creation
            enemyCreation -= Time.deltaTime;
            //countdown timer for bullet reload
            bulletReload -= Time.deltaTime;
            //ensure no rotation of the player
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
    //Check if player has hit an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player has hit an enemy then present the game over overlay
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "AStarEnemy")
        {
            Time.timeScale = 0;
            gameOver = true;
            GameOverScreen.SetActive(true);
        }
    }
    //The onclick listener for the retry button
    public void ResetGame()
    {
        Time.timeScale = 1;
        gameOver = false;
    }
    //This is to update the queue with the new player direction
    void updateQueue(Direction currentPlayerMovement)
    {
        //only holds up to 50 nodes
        if (playerMovement.Count == 50)
        {
            playerMovement.Dequeue();
        }
        playerMovement.Enqueue(currentPlayerMovement);
    }
    //This is to create a bullet
    void createBullet(float x, float y, float z, int rotation)
    {
        //makes new bullet
        GameObject bullet = new GameObject("Bullet");
        //set the position of the bullet
        bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        bullet.AddComponent<SpriteRenderer>();
        bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        bullet.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //sets physics to the bullet
        bullet.AddComponent<Rigidbody2D>();
        bullet.transform.Rotate(0, 0, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y));
        bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
        //add collider's events
        bullet.AddComponent<BoxCollider2D>();
        canShoot = false;
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

}




