using UnityEngine;
using System.Collections;

//No bouncing for a spiral thing
[RequireComponent(typeof(DestroyOnCollision))]
public class SpiralPath : MonoBehaviour
{
	Ray path;
	float creationTime = 0f;
	public float radius = 0f;
	public float angle = 0f;
	
	public float rotationsPerSecond = 1f;
	public float radiusExpansion = 1f;
	
	void Start()
	{
		path = new Ray(transform.position, transform.forward);
		rigidbody.useGravity = false; //This would screw up so much
		creationTime = Time.time;
	}
	
	//We want this function to coexist with physics
	void FixedUpdate()
	{
		float currentLife = Time.fixedTime - creationTime;
		
		Vector3 up = transform.up;
		Vector3 right = transform.right;
		
		angle += Time.fixedDeltaTime * rotationsPerSecond * Mathf.PI * 2f;
		radius += Time.fixedDeltaTime * radiusExpansion;
		
		Vector3 outward = Mathf.Cos(angle) * right + Mathf.Sin(angle) * up;
		transform.position = path.GetPoint(currentLife * rigidbody.velocity.magnitude) + outward * radius;
	}
}
