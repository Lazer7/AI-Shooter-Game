using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    int count;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        GameObject bullet;
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            bullet.AddComponent<Rigidbody>();
            bullet.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<CapsuleCollider>().enabled = false;
            bullet.GetComponent<Rigidbody>().AddForce(0f, 100f, 0f);
            count++;
            print(count);
            transform.Translate(0f, 1f, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            bullet.AddComponent<Rigidbody>();
            bullet.transform.Translate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            bullet.transform.Rotate(0, 0, 180);
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<CapsuleCollider>().enabled = false;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, (-100f), 0);
            count++;
            print(count);
            transform.Translate(0f, -1f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            bullet.AddComponent<Rigidbody>();
            bullet.transform.Translate(this.transform.position.x+2, this.transform.position.y, this.transform.position.z);
            bullet.transform.Rotate(0,0,90);
            bullet.GetComponent<CapsuleCollider>().enabled = false;
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(100f, 0f, 0);
            count++;
            print(count);
            transform.Translate(1f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            bullet.AddComponent<Rigidbody>();
            bullet.transform.Translate(this.transform.position.x-2, this.transform.position.y, this.transform.position.z);
            bullet.transform.Rotate(0, 0,270);
            bullet.GetComponent<CapsuleCollider>().enabled = false;
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().AddForce((-100f), 0f, 0f);
            count++;
            print(count);
            transform.Translate(-1f, 0f, 0f);
        }
    }
}
