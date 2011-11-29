using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	int enemiesKilled = 0;
	
	void EnemyKilled() { enemiesKilled++; }
	
	void OnGUI()
	{
		GUI.Label(new Rect(0f, 0f, 200f, 25f), "Enemies killed: " + enemiesKilled);
	}
}
