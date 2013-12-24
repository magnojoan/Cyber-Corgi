using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	bool paused = false;

	void OnMouseDown()
	{
		paused = togglePause();
	}
	/*
	void Update()
	{
		if(Input.GetButtonDown("pauseButton"))
			paused = togglePause();
	}*/
	
	void OnGUI()
	{
		//Add the buttons here that should show up in the middle...
		if(paused)
		{
			GUILayout.Label("Game is paused!");
			if(GUILayout.Button("Click me to unpause"))
				paused = togglePause();
		}
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	
	}
}
