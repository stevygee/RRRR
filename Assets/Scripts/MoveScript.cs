using UnityEngine;
using System.Collections;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector3 speed = new Vector3(10, 0, 0);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector3 direction = new Vector3(-1, 0, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			speed.z * direction.z);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody.velocity = movement;
	}
}