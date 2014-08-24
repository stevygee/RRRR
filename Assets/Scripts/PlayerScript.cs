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
		//float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		if(WorldScript.Instance.currentState != 0)
			movement = speed * inputX;

		// 5 - World switch
		bool worldSwitch = Input.GetButton("Fire1");
		worldSwitch |= Input.GetButton("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (worldSwitch)
		{
			WorldScript.Instance.switchWorld();
		}
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		Vector3 movement3D;

		if( rigidbody.position.x <= 3.5f && rigidbody.position.x >= -3.5f )
		{
			movement3D = new Vector3(movement, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		else
		{
			movement3D = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
			float clampedX = Mathf.Clamp(rigidbody.position.x, -3.5f, 3.5f);
			Vector3 position = new Vector3(clampedX, rigidbody.position.y, rigidbody.position.z);
			rigidbody.position = position;
		}

		rigidbody.velocity = movement3D;
	}
}