using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text NumText;
    float NumTime;
    public Canvas UICanvas;
    public Canvas EndCanvas;



    void start_numerator()
    {
        


        NumTime -= Time.deltaTime;
        if (NumTime <= 2)
            NumText.text = "2";
        if (NumTime <= 1)
            NumText.text = "1";
        if (NumTime <= 0)
        { 
            NumText.enabled = false;
            GameObject.Find("Game Controller").GetComponent<SpawnEnemies>().enabled = true;
            GameObject.Find("Game Controller").GetComponent<WeaponController>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;



 
        }
    }




    void set_EndUI()
    {
        GameObject[] bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lives <= 0)
        {
            UICanvas.enabled = false;
            EndCanvas.enabled = true;
            GameObject.Find("End Message").GetComponent<Text>().text = "YOU DIED";
            Cursor.visible = true;

        }
        if (GameObject.Find("Game Controller").GetComponent<SpawnEnemies>().testSpawn == false)
        {
        

            
                if (bulletArray.Length <= 1)
                {
                    if (GameObject.Find("Game Controller").GetComponent<WeaponController>().script.bullet_number <= 0)
                    {
                        UICanvas.enabled = false;
                        EndCanvas.enabled = true;
                        GameObject.Find("End Message").GetComponent<Text>().text = "NO BULLETS";
                        Cursor.visible = true;

                    }
                }
              }


    }



    
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        NumTime = 3;
        EndCanvas.enabled = false;

        GameObject.Find("Game Controller").GetComponent<SpawnEnemies>().enabled = false;
        GameObject.Find("Game Controller").GetComponent<WeaponController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;




    }

    // Update is called once per frame
    void Update()
    {
        start_numerator();
        set_EndUI();

        

    }
}
