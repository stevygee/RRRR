using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelper : MonoBehaviour
{
	
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectsHelper Instance;
	
	public AudioClip worldASound;
	public AudioClip worldBSound;
	public AudioClip worldChangeSound;
	public AudioClip menuSound;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}
	
	public void MakeWorldASound()
	{
		MakeSound(worldASound);
	}
	
	public void MakeWorldBSound()
	{
		MakeSound(worldBSound);
	}
	
	public void MakeWorldChangeSound()
	{
		MakeSound(worldChangeSound);
	}

	public void MakeMenuSound()
	{
		MakeSound(menuSound);
	}
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}