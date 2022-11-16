using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
	public string SoundName;
	public void Sound()
	{
		AudioManager.Instance.PlaySFX(SoundName);
	}
	
	public void Music(string music){
		AudioManager.Instance.PlayMusic(music);
	}
}
