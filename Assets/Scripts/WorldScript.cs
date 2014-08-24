using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {
	/// <summary>
	/// Singleton
	/// </summary>
	public static WorldScript Instance;

	public int currentState = 1;
	private float stateTime = 0f;
	private float transitionDuration = 2f;

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
	
	}
	
	// Update is called once per frame
	void Update () {
		stateTime += Time.deltaTime;

		if(stateTime >= transitionDuration)
		{
			if(currentState == TRANSITION_TO_B) { switchState(WORLD_B); }
			if(currentState == TRANSITION_TO_A) { switchState(WORLD_A); }
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
			MusicManager.Instance.SwitchWorldB();
		}
		else if( currentState.Equals(WORLD_B) )
		{
			switchState(TRANSITION_TO_A);
			MusicManager.Instance.SwitchWorldA();
		}
	}

	public bool isTransitioning() {
		return currentState == TRANSITION_TO_B || currentState == TRANSITION_TO_A;
	}

	public bool isWorldA() {
		return currentState == WORLD_A || currentState == TRANSITION_TO_A;
	}
}
