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
	public float speed = 20;
	
	// 2 - Store the movement
	private float movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = speed * inputX;
		
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		Vector3 movement3D = new Vector3(movement,
		                             rigidbody.velocity.y,
		                             rigidbody.velocity.z);

		rigidbody.velocity = movement3D;
	}
}