using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

     float xSpeed;
     float ySpeed;
     public float speed;
     public int lives;
    public float MoveTime;
     float ReloadTime;
    public float ReloadTimeStart;
    public float ReloadTimeEnd;
    public GameObject bullet;
    float MoveTime_Temp;
    float ReloadTime_Temp;
    Vector3 position;
    public GameObject explosion;
    public AudioSource explosion_sound;

    void move()
    {
       Vector3 screenposition;
       MoveTime_Temp -= Time.deltaTime;
       if (MoveTime_Temp <= 0)
       {
           xSpeed += Random.Range(-speed, speed);
           ySpeed += Random.Range(-speed, speed);

           xSpeed = Mathf.Clamp(xSpeed, -speed, speed);
           ySpeed = Mathf.Clamp(ySpeed, -speed, speed);
           MoveTime_Temp = MoveTime;
       }
        position.x += xSpeed;
        position.y += ySpeed;

        screenposition = Camera.main.WorldToViewportPoint(position);

        screenposition.x = Mathf.Clamp(screenposition.x, 0.05f, 0.95f);
        screenposition.y = Mathf.Clamp(screenposition.y, 0.5f, 0.90f);

        if (screenposition.y >= 0.90f || screenposition.y <= 0.5f)
        {
            ySpeed = -ySpeed;
        }
        if (screenposition.x >= 0.95f || screenposition.x <= 0.05f)
        {
           xSpeed = -xSpeed;
        }

        position = Camera.main.ViewportToWorldPoint(screenposition);
        transform.position = position;





    }
    void shoot()
    {
        ReloadTime_Temp -= Time.deltaTime;
        if (ReloadTime_Temp <= 0)
        {
            Vector3 bullet_position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            GameObject boltinst = Instantiate(bullet, bullet_position, bullet.transform.rotation) as GameObject;
            ReloadTime_Temp = ReloadTime;
        }

    }

        void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.gameObject.tag == "Bullet")
            lives -= Object.gameObject.GetComponent<BulletController>().strenght;
        if (lives <= 0)
            lives = 0;
    }
        void explode()
        {
            GameObject boom = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            Destroy(boom, 0.7f);
            explosion_sound.Play();
            Destroy(this.gameObject);

        }

	// Use this for initialization
	void Start () {

        position = transform.position;
        MoveTime_Temp = MoveTime;
        ReloadTime = Random.Range(ReloadTimeStart, ReloadTimeEnd);
        ReloadTime_Temp = ReloadTime;
		
	}
	
	// Update is called once per frame
	void Update () {

        move();
        shoot();
        if (lives <= 0)
            explode();
		
	}
}
