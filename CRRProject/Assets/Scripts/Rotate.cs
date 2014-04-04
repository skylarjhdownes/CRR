using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	void Start ()
	{
	
	}

	void Update () 
	{
		transform.Rotate (Vector3.up, 1f);
	}
}
