using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[SerializeField] GameObject MouseSensivity;
	[SerializeField] GameObject InvertY;
	[SerializeField] Settings MySettings;	
	// Awake is called when the script instance is being loaded.
	protected void Start()
	{
		MouseSensivity.GetComponent<Slider>().value = MySettings.mouseSensitivity;
		InvertY.GetComponent<Toggle>().isOn = MySettings.invert_y_axis;
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Cursor.lockState = CursorLockMode.None;
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		Cursor.lockState=CursorLockMode.Locked;
	}
	
	public void Delete(){
		SaveManager.DeletePlayerData();
		//Globals.Restart();
	}
}
