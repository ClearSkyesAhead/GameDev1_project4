using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public Vector2 spread = Vector2.zero;
	public bool semiAutomatic = true;
	public float firingDelay = 0.25f;
	
	public Projectile[] bullets;
	public int selectedProjectile = 0;
	
	float lastFireTime = 0f;
	
	void Update()
	{
		//Figure out if we should be firing:
		bool delayPassed = Time.time - lastFireTime > firingDelay;
		bool buttonJustPressed = Input.GetMouseButtonDown(0);
		bool buttonCurrentlyPressed = Input.GetMouseButton(0);
		
		//Delay must have passed, and the button should be down, and if semi-automatic, just down too
		if (delayPassed && buttonCurrentlyPressed && (!semiAutomatic || buttonJustPressed))
		{
			if (selectedProjectile >= bullets.Length || selectedProjectile < 0)
				return;
			Projectile bullet = bullets[selectedProjectile];
			
			//Spawn the bullet
			Projectile p = (Projectile)Instantiate(bullet);
			
			//Figure out what direction it's going, with spread (advanced)
			Vector3 forward = transform.forward;
			Vector3 right = transform.right;
			Vector3 up = transform.up;
			p.transform.forward = forward + 
				Random.Range(-1f, 1f) * spread.x * right + 
				Random.Range(-1f, 1f) *	spread.y * up;
			
			//Put it juuuust in front of us
			p.transform.position = transform.position + forward * 0.1f;
			
			//Update our firing time for the delay
			lastFireTime = Time.time;
		}
		
		//Change weapons with spacebar
		if (Input.GetButtonDown("Jump"))
		{
			//Change projectile and wrap
			selectedProjectile = (selectedProjectile + 1) % bullets.Length;
		}
	}
	
	void OnGUI()
	{
		if (selectedProjectile >= bullets.Length || selectedProjectile < 0)
			return;
		string name = bullets[selectedProjectile].name;
		
		GUI.Label(new Rect(0f, 15f, 200f, 25f), "Selected weapon: " + name);
	}
}
