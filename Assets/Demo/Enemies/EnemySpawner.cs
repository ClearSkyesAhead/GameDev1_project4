using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public float spawnChance = 0.01f;
	public Vector3 spawnArea = new Vector3(9f, 5f, 9f);
	public Enemy enemyPrefab;
	
	void Update()
	{
		//Randomly spawn enemies
		if (Random.value < spawnChance && enemyPrefab)
		{
			//Pick a position in a box around this object
			Vector3 pos = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
			pos.Scale(spawnArea);
			
			//Spawn the enemy and put them in the right spot
			Enemy e = (Enemy)Instantiate(enemyPrefab);
			e.transform.position = transform.position + pos;
			
			//Parent them to us, so this object can receive messages on death
			e.transform.parent = transform;
		}
	}
}
