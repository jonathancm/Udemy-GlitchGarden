using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	[SerializeField] Slider volumeSlider = null;
	[SerializeField] float defaultVolume = 0.8f;
	[SerializeField] Slider difficultySlider = null;
	[SerializeField] int defaultDifficulty = 1;

	// Cached References
	MusicPlayer musicPlayer;
	LevelLoader levelLoader;

	private void Start()
	{
		levelLoader = FindObjectOfType<LevelLoader>();
		musicPlayer = FindObjectOfType<MusicPlayer>();

		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		difficultySlider.value = (float) PlayerPrefsController.GetDifficulty();
	}

	private void Update()
	{
		if (musicPlayer)
		{
			musicPlayer.SetVolume(volumeSlider.value);
		}
		else
		{
			Debug.LogWarning("No music player found...");
		}
	}

	public void SaveAndExit()
	{
		// Save Options
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty((int)difficultySlider.value);


		levelLoader.LoadStartMenu();
	}

	public void SetDefaults()
	{
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}
}
