using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector3 position;

    public float speed;
    public int  bullet_number;
    public int lives;

    public GameObject explosion;
    public AudioSource explosion_sound;

    public GameObject bullet;
    public AudioSource bullet_sound;


    void move()
    {
        Vector3 screenposition;
        
            if (Input.GetAxis("Mouse X") != 0)
            {
                position.x += Input.GetAxis("Mouse X") * speed;
            }

            if (Input.GetAxis("Mouse Y") !=0)
            {
                position.y += Input.GetAxis("Mouse Y") * speed;
            }
            screenposition = Camera.main.WorldToViewportPoint(position);

       screenposition.x= Mathf.Clamp(screenposition.x,0.05f,0.95f);
       screenposition.y= Mathf.Clamp(screenposition.y, 0.1f, 0.90f);


        position = Camera.main.ViewportToWorldPoint(screenposition);

            

            transform.position = position;


    }

    void OnTriggerEnter2D(Collider2D Object)
    {
       if (Object.gameObject.tag == "Enemy Bullet")
           lives -= Object.gameObject.GetComponent<BulletController>().strenght;
        if (lives <= 0)
            lives = 0;
        if (Object.gameObject.tag == "Enemy")
            lives = 0;
    }

    void explode()
    {
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(boom, 0.7f);
        explosion_sound.Play();

    }

    void shoot()
    {
        Vector3 bullet_position = new Vector3(transform.position.x, transform.position.y +2, transform.position.z+1);
        GameObject boltinst = Instantiate(bullet, bullet_position, bullet.transform.rotation) as GameObject;
        bullet_sound.Play();
        bullet_number--;
        if (bullet_number <= 0)
            bullet_number = 0;
    }

	// Use this for initialization
	void Start () {
        position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        move();

        if (lives == 0)
        {
            explode();
            Destroy(this.gameObject);
        }
		
        if (Input.GetMouseButtonDown(0) && bullet_number>0)
        {
            shoot();
        }

        if (lives > 3) 
        lives = 3;

	}
}
