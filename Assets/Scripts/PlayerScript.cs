using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector3 speed = new Vector3(50, 0, 50);
	
	// 2 - Store the movement
	private Vector3 movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector3(
			speed.x * inputX,
			0,
			0);
		
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody.velocity = movement;
	}
}