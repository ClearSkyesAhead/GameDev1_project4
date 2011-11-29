using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour
{
	public bool lockMouse = true;
	public float sensitivity = 3f;
	
	void Update()
	{
		//Hide the cursor and always re-center it after each frame.
		//Use escape to temporarily unlock it in the editor.
		Screen.lockCursor = lockMouse;
		
		//Retrieve mouse movement from Unity's Input system, set up to use as angle adjustments.
		//See Edit\Project Settings\Input to configure.
		Vector3 mouseMovement = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
		mouseMovement *= sensitivity;
		
		//Retrieve the camera's current rotation, adjust it, and set it back.
		Vector3 currentEuler = transform.localEulerAngles;
		Vector3 newEuler = currentEuler + mouseMovement;
		transform.localEulerAngles = newEuler;
	}
}
