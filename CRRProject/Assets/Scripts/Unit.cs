using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Unit : MonoBehaviour
{
	
	protected CharacterController control;
	
	protected Vector3 move = Vector3.zero;
	
	public float walkSpeed = 6f;
	public float runSpeed = 10f;
	public float jumpSpeed = 8f;
	public float dashSpeed = 20f;

	protected float blinkCooldown = 0f;

	protected bool jumping = false;
	protected bool running = false;
	protected bool dashingRight = false;
	protected bool blinkingRight = false;
	protected bool unitAlive = true;

	protected Vector3 gravity = Vector3.zero;
	
	// Use this for initialization
	public virtual void Start ()
	{
		control = GetComponent<CharacterController>();
		
		if (!control)
		{
			Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
			enabled = false;
		}
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
		//control.SimpleMove (move * moveSpeed);
		
		if (running)
			move *= runSpeed;
		else
			move *= walkSpeed;
		
		if (!control.isGrounded)
		{
			gravity += Physics.gravity * Time.deltaTime;	
		}
		else
		{
			gravity = Vector3.zero;	
			
			if (jumping)
			{
				gravity.y = jumpSpeed;
				jumping = false;
			}

			if (dashingRight)
			{
				gravity.x = dashSpeed;
				//move += new Vector3(dashSpeed, 0f, 0f);
				dashingRight = false;
			}
			if (blinkingRight)
			{
				transform.position += new Vector3(10f, 0, 0);
				blinkingRight = false;
			}
		}


		move += gravity;
		
		control.Move (move * Time.deltaTime);
	}
}
