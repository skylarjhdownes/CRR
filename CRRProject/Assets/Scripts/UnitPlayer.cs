using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit
{
	float cameraRotX = 0f;
	
	public float cameraPitchMax = 45f;
	
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
			jump = true;	
		}
		
		running = Input.GetKey (KeyCode.LeftShift)  || Input.GetKey (KeyCode.RightShift);
		
		base.Update ();
	}
}