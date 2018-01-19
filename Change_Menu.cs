using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Menu : MonoBehaviour {
    public GameObject Canvas_Main;
    public GameObject Canvas_Start;
    public GameObject Canvas_Options;
    public GameObject Canvas_HighScore;
    public GameObject UI_Elements;
    public GameObject Video_Menu;
    public GameObject Audio_Menu;
    public GameObject Highscore_Menu;
    public GameObject Stats_Menu;



    public void Delete()
    {
        Canvas_Main.SetActive(false);
        Canvas_Start.SetActive(false);
        Canvas_Options.SetActive(false);
        Canvas_HighScore.SetActive(false);
        UI_Elements.SetActive(false);
    }
    
    void Delete_Options()
    {
        Video_Menu.SetActive(false);
        Audio_Menu.SetActive(false);
    }

    void Delete_InfoOptions()
    {
        Highscore_Menu.SetActive(false);
        Stats_Menu.SetActive(false);
    }
    public void Change_ToMenu()
    {   Delete();
        Canvas_Main.SetActive(true);
        UI_Elements.SetActive(true);
    }
    public void Change_ToStart()
    { Delete();
        Canvas_Start.SetActive(true);
        UI_Elements.SetActive(true);
    }
    public void Change_ToOptions()
    {
        Delete();
        Canvas_Options.SetActive(true);
        Video_Menu.SetActive(false);
        Audio_Menu.SetActive(false);
    }

    public void Change_ToHighScore()
    {
        Delete();
        Canvas_HighScore.SetActive(true);
        Delete_InfoOptions();

    }

    public void Change_ToVideo()
    {
        Delete_Options();
        Video_Menu.SetActive(true);
    }
    public void Change_ToAudio()
    {
        Delete_Options();
        Audio_Menu.SetActive(true);
    }

    public void Change_ToHighscoreMenu()
    {
        Delete_InfoOptions();
        Highscore_Menu.SetActive(true);
    }

    public void Change_ToStats()
    {
        Delete_InfoOptions();
        Stats_Menu.SetActive(true);
    }

    
	// Use this for initialization
	void Start () {

        Change_ToMenu();


		
	}
	

}
