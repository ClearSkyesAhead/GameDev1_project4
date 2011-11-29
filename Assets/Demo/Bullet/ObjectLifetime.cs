using UnityEngine;
using System.Collections;

public class ObjectLifetime : MonoBehaviour
{
	public float lifetime = 5f;
	
	float startTime = 0f;
	void Start()
	{
		startTime = Time.time;
	}
	
	void Update()
	{
		if (Time.time - startTime > lifetime)
			GameObject.Destroy(gameObject);
	}
}
