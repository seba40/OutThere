using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCalculator : MonoBehaviour {

    GameObject[] enemies;
    public int score;
    public Text Score_UI;
    public Text SecondScoreUI;

	// Use this for initialization
	void Start () {

        score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyController>().lives <= 0)
            {
                score++;
                
            }
        }
        Score_UI.text = score.ToString();
        SecondScoreUI.text = score.ToString();
   
	}
}
