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

	private bool transitionMusicIsPlaying = true;
	private bool looping = false;
	private bool isWorldA = true;
	private bool isMenu = false;

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

	public void SwitchWorld() {
		isWorldA = !isWorldA;

		if(audio.isPlaying == true) {
			audio.Stop();
		}
		audio.clip = worldChange;
		audio.loop = false;
		audio.Play();

		transitionMusicIsPlaying = true;
		looping = false;
	}
}