using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	/// <summary>
	/// Singleton
	/// </summary>
	public static MusicManager Instance;

	public AudioClip menuLoop;
	public AudioClip worldALoop;
	public AudioClip worldBLoop;
	public AudioClip worldChange;

	private bool transitionMusicIsPlaying = false;
	private bool looping = true;
	private bool isWorldA = true;
	private bool isMenu = true;

	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of MusicManager!");
		}
		Instance = this;
	}

	void Start() {
		PlayBackgroundMusic();
	}
	
	void Update() {
		if(!audio.isPlaying) {
			transitionMusicIsPlaying = false;
		}
		if(!transitionMusicIsPlaying && !looping) {
			looping = true;
			LoopBackgroundMusic();
		}
	}
	
	private void PlayBackgroundMusic() {
		if(audio.isPlaying == true) {
			audio.Stop();
		}
		audio.Play();
	}
	
	private void LoopBackgroundMusic() {
		if(audio.isPlaying == true) {
			audio.Stop();
		}
		if(isMenu)
		{
			audio.clip = menuLoop;
		} else {
			if(isWorldA) {
				audio.clip = worldALoop;
			} else {
				audio.clip = worldBLoop;
			}
		}
		audio.loop = true;
		audio.Play();
	}

	public void SwitchWorldA(bool transition) {
		isWorldA = true;
		isMenu = false;
		SwitchWorld(true, transition);
	}

	public void SwitchWorldB(bool transition) {
		isWorldA = false;
		isMenu = false;
		SwitchWorld(false, transition);
	}
	
	void SwitchWorld(bool worldA, bool transition) {
		if(audio.isPlaying == true) {
			audio.Stop();
		}
		if(transition)
		{
			audio.clip = worldChange;
			audio.loop = false;
		}
		else
		{
			if(worldA)
			{
				audio.clip = worldALoop;
			}
			else
			{
				audio.clip = worldBLoop;
			}
		}
		audio.Play();

		if(transition) {
			transitionMusicIsPlaying = true;
			looping = false;
		}
	}
}