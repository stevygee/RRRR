using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip musicLoop;
	private bool introMusicIsPlaying = true;
	private bool looping = false;

	void Start() {
		PlayBackgroundMusic();
	}
	
	void Update() {
		if(!audio.isPlaying) {
			introMusicIsPlaying = false;
		}
		if(!introMusicIsPlaying && !looping) {
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
		audio.clip = musicLoop;
		audio.loop = enabled;
		audio.Play();
	}
}