using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
	[SerializeField] GameObject MouseSensivity;
	[SerializeField] GameObject InvertY;
	[SerializeField] GameObject MusicVolume;
	[SerializeField] GameObject SFXVolume;
	[SerializeField] GameObject Fullscreen;
	[SerializeField] Settings MySettings;	
	[SerializeField] TextMeshProUGUI misionTitle;
	[SerializeField] TextMeshProUGUI mision;
	[SerializeField] GameObject newGameButton;
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(newGameButton==null)return;
		PlayerData playerData = SaveManager.LoadPlayerData();
		if(playerData==null){
			newGameButton.SetActive(false);
		}else{
			newGameButton.SetActive(true);
		}
	}
	// Awake is called when the script instance is being loaded.
	protected void Start()
	{
		MouseSensivity.GetComponent<Slider>().value = MySettings.mouseSensitivity;
		InvertY.GetComponent<Toggle>().isOn = MySettings.invert_y_axis;
		MusicVolume.GetComponent<Slider>().value = MySettings.musicVolume;
		SFXVolume.GetComponent<Slider>().value = MySettings.sfxVolume;
		Fullscreen.GetComponent<Toggle>().isOn = MySettings.isFullScreen;
	}
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Cursor.lockState = CursorLockMode.None;
		if(mision==null)return;
		misionTitle.text = Globals.Instance.mision[0];
		mision.text = Globals.Instance.mision[1];
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		Cursor.lockState=CursorLockMode.Locked;
	}
	
	public void NewGame(string scene){
		SaveManager.DeletePlayerData();
		SceneManagerNextScene(scene);
		Cursor.lockState=CursorLockMode.Locked;
		//Globals.Restart();
	}
	
	public void SceneManagerQuitScene(){
		LoadScene.Instance.Quit();
	}
	
	public void SceneManagerNextScene(string scene){
		LoadScene.Instance.LoadNextScene(scene);
		Cursor.lockState=CursorLockMode.Locked;
	}
	
	public void SetFullscreen(){
		Screen.fullScreen = Fullscreen.GetComponent<Toggle>().isOn;
	}
}
