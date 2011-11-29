using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public float moveSpeed = 3f;
	
	void Update()
	{
		//Grab our movement axes
		Vector3 right = transform.right;
		Vector3 fwdHorizontal = Vector3.Cross(right, Vector3.up);
		
		//Get the input and scale it appropriately
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		Vector3 movement = (right * input.x + fwdHorizontal * input.z) * Time.deltaTime * moveSpeed;
		
		//Move us!
		transform.position += movement;
	}
}
