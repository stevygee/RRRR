using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip menuLoop;
	public AudioClip worldALoop;
	public AudioClip worldBLoop;

	private bool transitionMusicIsPlaying = true;
	private bool looping = false;
	private bool isWorldA = true;
	private bool isMenu = false;

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
	
	void PlayBackgroundMusic() {
		if(audio.isPlaying == true) {
			audio.Stop();
		}
		audio.Play();
	}
	
	void LoopBackgroundMusic() {
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
		audio.loop = enabled;
		audio.Play();
	}
}