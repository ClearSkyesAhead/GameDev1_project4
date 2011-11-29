using UnityEngine;
using System.Collections;

public enum SplashDamageType { Linear, Square }
public class ExplodeOnDestroy : MonoBehaviour
{
	public float damageArea = 5f;
	public float maxSplashDamage = 5f;
	public SplashDamageType splashType = SplashDamageType.Linear;
	public ParticleEmitter particles;
	
	void OnDestroy()
	{
		Vector3 pos = transform.position;
		
		//Find all the enemies in the world right now
		Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
		
		//C# foreach iterates over an Enumerable collection
		foreach(Enemy e in enemies)
		{
			//Figure out how far the explosion is from the enemy
			Vector3 enemyPos = e.transform.position;
			float dist = (enemyPos - pos).magnitude;
			if (dist < damageArea)
			{
				//How much damage are we doing to the enemy?
				float damage;
				if (splashType == SplashDamageType.Linear)
					damage = maxSplashDamage * dist / damageArea;
				else
					damage = maxSplashDamage * Mathf.Pow(dist / damageArea, 2f);
				e.Damage(damage);
			}
		}
		
		//If we have a valid particle emitter reference, spawn one
		if (particles)
		{
			ParticleEmitter p = (ParticleEmitter)Instantiate(particles);
			p.transform.position = pos;
		}
	}
}
