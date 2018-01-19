
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemy;
    Vector3 position;
    public int spawn_number;
    WeaponController script;
    public bool testSpawn;
    PlayerController PlayerScript;
    int temp;


    void spawn()
    {
        Vector3 viewportPosition;
        for (int i = 1; i <= spawn_number; i++)
        {
            position = new Vector3(Random.Range(0.2f, 0.8f), Random.Range(0.55f, 0.8f), 0);
            viewportPosition = Camera.main.ViewportToWorldPoint(position);
            viewportPosition.z = -0.71f;
            GameObject clone = Instantiate(enemy, viewportPosition, enemy.transform.rotation) as GameObject;
            clone.GetComponent<EnemyController>().enabled = true;
        }
    }

   public  bool TestRespawn()
    {
        
        if (GameObject.Find("Game Controller").GetComponent<ScoreCalculator>().score == spawn_number+temp)
        {
            temp = GameObject.Find("Game Controller").GetComponent<ScoreCalculator>().score;
            return true;
            
        }
        else
            return false;
    }
    // Use this for initialization
    void Start()
   {
       temp = GameObject.Find("Game Controller").GetComponent<ScoreCalculator>().score;
        enemy.GetComponent<EnemyController>().enabled = false;
        script = GameObject.Find("Game Controller").GetComponent<WeaponController>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();





		
	}
	
	// Update is called once per frame
	void Update () {

        if (TestRespawn())
        {



            testSpawn = true;
            spawn_number++;

            spawn();
            
        }
        else 
            testSpawn = false;
        
        if (testSpawn ==true)
        {
            PlayerScript.lives++;

        }

	}
}
