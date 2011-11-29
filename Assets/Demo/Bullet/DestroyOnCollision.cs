using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
	//This script exemplifies that multiple MonoBehaviours on the same object
	//All can receive the same event
	void OnCollisionEnter(Collision collisionInfo)
	{
		Destroy(gameObject);
	}
}
