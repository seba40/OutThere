using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	public AudioSource click;
	void Update()
	{
		Play ();
	}
	public void Play()
	{  
		if (Input.GetKeyDown(KeyCode.Mouse0))
			click.Play();
	}

}
