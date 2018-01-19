using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Options : MonoBehaviour {
     GameObject[] music;
     GameObject[] sounds;
    float volumeMusic;
    float volumeSounds;
    float brightness;
    public Camera camera;
    public Slider slider_brightness;
    public Slider slider_volumeMusic;
    public Slider slider_volumeSounds;
    public Toggle toggle;
    string[] read;
    public Text brightness_values;
    public Text music_values;
    public Text sound_values;

    //for resolutions
    public Text rez;
    int index = 0;
    Resolution[] resolutions;
    public GameObject apply;

    void set_numbers()
    {
        brightness_values.text = slider_brightness.value.ToString();
        music_values.text = slider_volumeMusic.value.ToString();
        sound_values.text = slider_volumeSounds.value.ToString();
    }
    void Read()
    { //reading options from file 
        read = File.ReadAllLines("settings.txt");
        float.TryParse(read[0], out brightness);
        float.TryParse(read[1], out volumeMusic);
        float.TryParse(read[2], out volumeSounds);

        slider_brightness.value = (brightness * 10) / 1.5f;
        slider_volumeMusic.value = volumeMusic * 10.0f;
        slider_volumeSounds.value = volumeSounds * 10.0f;
    }

    public void change_resolution(string dir)
    {   int lenght = resolutions.Length;
        if (dir=="right")
            if (index < lenght - 1)
            {   index++;
                rez.text = resolutions[index].width.ToString() + " x " + resolutions[index].height.ToString();
                apply.SetActive(true);

            }
         if (dir=="left")
                if (index > 0)
                {
                    index--;
                    rez.text = resolutions[index].width.ToString() + " x " + resolutions[index].height.ToString();
                    apply.SetActive(true);
                }

    }

    public void Apply()
    {
        bool val = Screen.fullScreen;
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, val);
        apply.SetActive(false);
    }

    public void set_brightness(float new_Brightness)
    {
        brightness = new_Brightness * 0.15f;
        read[0] = brightness.ToString();
        File.WriteAllLines("settings.txt", read);
    }

    public void set_volume(float new_Volume)
    {
        volumeMusic = new_Volume / 10.0f; ;
        read[1] = volumeMusic.ToString();
        File.WriteAllLines("settings.txt", read);
    }
    public void set_sounds(float new_Volume)
    {
        volumeSounds = new_Volume / 10.0f; ;
        read[2] = volumeSounds.ToString();
        File.WriteAllLines("settings.txt", read);
    }


    public void windowed (bool val)
    {
        if (val)
            Screen.SetResolution(Screen.width, Screen.height, false);
        else
            Screen.SetResolution(Screen.width, Screen.height, true);

    }

    public void reset()
    {
        slider_brightness.value = 7;
        slider_volumeMusic.value = 10;
        slider_volumeSounds.value = 10;

        brightness = 1.05f;
        volumeMusic = 1.0f;
        volumeSounds = 1.0f;
        toggle.isOn = false;
        Screen.SetResolution(Screen.width, Screen.height, true);
        File.WriteAllLines("settings.txt", read);
    }

	// Use this for initialization
	void Start () {
        music = GameObject.FindGameObjectsWithTag("Music");
        sounds = GameObject.FindGameObjectsWithTag("Audio");


        Cursor.visible = true;
        Read();
        // set windowed button
        if (Screen.fullScreen == true)
            toggle.isOn = false;
        else
            toggle.isOn = true;
        // set resolution text
        resolutions = Screen.resolutions;

        rez.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        apply.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject sound in music)
         sound.GetComponent<AudioSource>().volume =volumeMusic;
        foreach (GameObject sound in sounds)
            sound.GetComponent<AudioSource>().volume = volumeSounds;

        camera.GetComponent<Brightness>().brightnessAmount = brightness;
        set_numbers();
		
	}
}
