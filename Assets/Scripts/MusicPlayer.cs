using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

	// Cached References
	AudioSource audioSource;

	// State Variables
	public static MusicPlayer instance = null;

	private void Awake()
	{
		SetupSingleton();
	}

	private void SetupSingleton()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		//audioSource.volume = PlayerPrefsController.GetMasterVolume();
		audioSource.Play();
	}

	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
