using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LifeCalculator : MonoBehaviour {

     GameObject[] life_image;
    int player_life;

	// Use this for initialization
	void Start () {

        
        life_image = GameObject.FindGameObjectsWithTag("Life").OrderBy(go => go.name).ToArray();
	}
	
	// Update is called once per frame
	void Update () {
        player_life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lives;
        for (int i = 0; i < 3;i++ )
        {
            if (i < player_life)
                life_image[i].SetActive(true);
            else
                life_image[i].SetActive(false);
        }
		
	}
}
