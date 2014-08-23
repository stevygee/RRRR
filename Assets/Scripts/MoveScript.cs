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
	
	private Vector3 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector3(
			speed.x * direction.x * Time.deltaTime,
			speed.y * direction.y * Time.deltaTime,
			speed.z * direction.z * Time.deltaTime);

		transform.Translate(movement);
	}

	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		//rigidbody.velocity = movement;
	}
}