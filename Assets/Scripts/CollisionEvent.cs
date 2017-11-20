using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            Destroy(collision.collider.gameObject);
            if (this.gameObject.name == "Enemy")
            {
                Destroy(this.gameObject);
            }
        }

    }
}
