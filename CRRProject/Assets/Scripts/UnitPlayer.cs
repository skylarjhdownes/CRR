using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{

	// Use this for initialization
	public override void Start ()
	{
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		// camera

		Camera.main.transform.position = new Vector3 (transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		Camera.main.transform.LookAt (transform);

		// movement

		move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, 0f); //Input.GetAxis ("Vertical"));
		
		move.Normalize();
		
		move = transform.TransformDirection (move);
		
		if (Input.GetKey(KeyCode.Space) && control.isGrounded)
		{
			jumping = true;	
		}
		
		running = Input.GetKey (KeyCode.LeftShift)  || Input.GetKey (KeyCode.RightShift);

		// abilities

		// dash
		if (Input.GetKey(KeyCode.E) && control.isGrounded)
		{
			dashingRight = true;
		}
		if (Input.GetKey(KeyCode.F) && blinkCooldown <= Time.time) //&& (Physics.OverlapSphere(transform.position += new Vector3(4f, 0, 0), 5).Length == 0))
		{
			blinkCooldown = Time.time + 3f;
			blinkingRight = true;
		}

		base.Update ();

	}
}
