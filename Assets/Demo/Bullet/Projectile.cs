using UnityEngine;
using System.Collections;

//This attribute means Unity will automatically add the component along with this if it's not there
//It will also prevent you from removing the component
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	public float speed;
	public float damage;
	public Color bulletColor = Color.white;
	
	public ParticleEmitter emitter;
	private ParticleEmitter myEmitter;
	
	void Start()
	{
		//Start us off moving in the right direction
		rigidbody.velocity = transform.forward * speed;
		
		//This is easier than making a new material just to have a different color...
		if (renderer)
			renderer.material.color = bulletColor;
		
		//If we want a particle trail, we should instantiate and attach it
		//So its particles can continue to die after the object dies
		if (emitter)
		{
			myEmitter = (ParticleEmitter)Instantiate(emitter);
			myEmitter.transform.parent = transform;
			myEmitter.transform.localPosition = Vector3.zero;
		}
	}
	
	//This function will only be called if this is a non-kinematic rigidbody
	//See the matrix halfway down on http://unity3d.com/support/documentation/Manual/Physics.html
	void OnCollisionEnter(Collision collisionInfo)
	{
		//Deal damage to an enemy if we collided with one
		Enemy e = collisionInfo.gameObject.GetComponent<Enemy>();
		if (e)
			e.Damage(damage * speed / rigidbody.velocity.magnitude);
	}
	
	//Then when we die, detach and stop our particle emitter so it can die on its own
	void OnDestroy()
	{
		if (myEmitter)
		{
			myEmitter.transform.parent = null;
			myEmitter.emit = false;
		}
	}
}
