using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float boltspeed;
    public int strenght;
    public bool isEnemy;


	// Use this for initialization
	
	// Update is called once per frame

    void move()
    {
        if (isEnemy == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + boltspeed, transform.position.z);
        }
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - boltspeed, transform.position.z);

       if (transform.position.y > 17 || transform.position.y < -5)
            Destroy(this.gameObject);


    }



    void OnTriggerEnter2D(Collider2D Object)
    {
        if (isEnemy == false)
        {
            if (Object.gameObject.tag == "Enemy")
                Destroy(this.gameObject);
        }
        else
            if (Object.gameObject.tag == "Player")
                Destroy(this.gameObject);


    }
	void Update () {

        if (gameObject.name != "bolt" && gameObject.name != "bolt_enemy")
            move();



		
	}
}
