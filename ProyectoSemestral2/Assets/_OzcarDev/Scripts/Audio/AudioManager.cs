using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public Sound[] musicSounds, sfxSounds;
	public AudioSource musicSource, sfxSource;
	public Settings settings;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		PlayMusic("theme_1");
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		musicSource.volume=settings.musicVolume;
		sfxSource.volume= settings.sfxVolume;
	}
	
	
	public void PlayMusic(string name)
	{
		Sound s = Array.Find(musicSounds, x => x.name == name);

		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			musicSource.clip = s.clip;
			//musicSource.volume = s.volume*settings.musicVolume;
			musicSource.Play();
			musicSource.loop = true;
		}
	}

	public void PlaySFX(string name)
	{
		Sound s = Array.Find(sfxSounds, x => x.name == name);

		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			//sfxSource.volume = s.volume*settings.sfxVolume;
			sfxSource.PlayOneShot(s.clip);
		}
	}
}