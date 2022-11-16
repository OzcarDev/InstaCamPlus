
using UnityEngine;

[CreateAssetMenu(menuName = "Create Options Settings")]


public class Settings : ScriptableObject
{
	public bool invert_y_axis;
	public bool isFullScreen;
	public float mouseSensitivity;
	public float musicVolume;
	public float sfxVolume;
	
	
	
	public void SetYaxis(bool value){
		invert_y_axis = value;
	}
	
	public void SetMouseSensitivity(float value){
		mouseSensitivity = value;
	}
	
	public void SetMusicVolume(float value){
		musicVolume = value;
		
	}
	
	public void SetSFXVolume(float value){
		sfxVolume=value;
		 
	}
	
	public void SetFullscreen(bool value){
		isFullScreen = value;
	}
	
	public void Get(){
		
	}
}
