using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float health = 20f;
	float maxHealth;
	
	void Start()
	{
		//Used for coloring
		maxHealth = health;
		
		//If we can, make them a cool color
		if (renderer)
		{
			float color = health / maxHealth;
			renderer.material.color = new Color(1 - color, color, 0f);
		}
	}
	
	public void Damage(float amount)
	{
		//Don't do negative damage
		if (amount <= 0)
			return;
		
		health -= amount;
		if (health <= 0)
		{
			Destroy(gameObject);
			
			//Let our parent(s) know that we've died
			SendMessageUpwards("EnemyKilled", SendMessageOptions.DontRequireReceiver);
		}
		
		else if (renderer)
		{
			float color = health / maxHealth;
			renderer.material.color = new Color(1 - color, color, 0f);
		}
	}
}
