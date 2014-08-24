using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {
	/// <summary>
	/// Singleton
	/// </summary>
	public static WorldScript Instance;

	private GameObject levelRoot;

	public int currentState = 1;
	private float stateTime = 0f;

	public float startDuration = 3f;
	public float transitionDuration = 2f;

	private static int START = 0;
	private static int WORLD_A = 1;
	private static int TRANSITION_TO_B = 2;
	private static int WORLD_B = 3;
	private static int TRANSITION_TO_A = 4;
	private static int GAME_OVER = 5;

	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of WorldScript!");
		}
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		levelRoot = GameObject.FindGameObjectWithTag("LevelRoot");
	}
	
	// Update is called once per frame
	void Update () {
		stateTime += Time.deltaTime;
		Vector3 rotation = new Vector3();

		if(currentState == START)
		{
			if(stateTime > startDuration)
			{
				switchState(WORLD_A);
				MusicManager.Instance.SwitchWorldA(false);
			}
		}
		else if(currentState == TRANSITION_TO_B)
		{
			if(stateTime > transitionDuration)
			{
				switchState(WORLD_B);
				rotation = new Vector3(0, 0, 180f);
			}
			else
			{
				rotation = new Vector3(0, 0, stateTime * 0.5f * 180f);
			}
			levelRoot.transform.localEulerAngles = rotation;
		}
		else if(currentState == TRANSITION_TO_A)
		{
			if(stateTime > transitionDuration)
			{
				switchState(WORLD_A);
				rotation = new Vector3(0, 0, 0f);
			}
			else
			{
				rotation = new Vector3(0, 0, stateTime * 0.5f * 180f + 180f);
			}
			levelRoot.transform.localEulerAngles = rotation;
		}
	}
	
	void switchState(int newState) {
		currentState = newState;
		stateTime = 0f;
	}

	public void switchWorld() {
		if( currentState.Equals(WORLD_A) )
		{
			switchState(TRANSITION_TO_B);
			MusicManager.Instance.SwitchWorldB(true);
		}
		else if( currentState.Equals(WORLD_B) )
		{
			switchState(TRANSITION_TO_A);
			MusicManager.Instance.SwitchWorldA(true);
		}
	}

	public bool isTransitioning() {
		return currentState == TRANSITION_TO_B || currentState == TRANSITION_TO_A;
	}

	public bool isWorldA() {
		return currentState == WORLD_A || currentState == TRANSITION_TO_A;
	}
}
