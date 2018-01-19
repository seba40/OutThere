using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponController : MonoBehaviour {
     int startBullets;
    public Text bullet_UI;
    public PlayerController script;
	// Use this for initialization

	void Start () 
    {   
        startBullets = 2;
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        script.bullet_number = startBullets;
        

	}

    void reload()
    {
        if (GameObject.Find("Game Controller").GetComponent<SpawnEnemies>().testSpawn == true)
        {

            startBullets++;
            script.bullet_number = startBullets;
        }
        if (script.bullet_number <= 0)
            if (GameObject.Find("Game Controller").GetComponent<SpawnEnemies>().TestRespawn() == true)
            {
                startBullets++;
                script.bullet_number = startBullets;

            }
    }

	
	// Update is called once per frame
	void Update () {

        reload();

        bullet_UI.text = script.bullet_number.ToString();
	}
}
